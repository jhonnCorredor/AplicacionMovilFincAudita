package com.sena.fincaudita.Farm

import android.os.Bundle
import android.text.Editable
import android.text.TextWatcher
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.*
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.android.volley.Request
import com.android.volley.toolbox.JsonArrayRequest
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.sena.fincaudita.Config.urls
import com.sena.fincaudita.Entity.Farm
import com.sena.fincaudita.Entity.Lot
import com.sena.fincaudita.Entity.Supplie
import com.sena.fincaudita.R
import org.json.JSONArray
import org.json.JSONObject

class FormFarmFragment : Fragment() {

    private var listCitys = mutableListOf<String>()
    private var cityIdMap = HashMap<String, Int>()
    private var cityId: Int? = null
    private var listUsers = mutableListOf<String>()
    private var userIdMap = HashMap<String, Int>()
    private var userId: Int? = null
    private var listCrops = mutableListOf<String>()
    private var cropIdMap = HashMap<String, Int>()
    private var selectedCropIds = mutableListOf<Int>()
    private var farm: Farm? = null
    private lateinit var txtHectareas: EditText
    private var lots: MutableList<Lot>? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {
            farm = it.getParcelable(ARG_FARM)
            lots = it.getParcelableArrayList(ARG_LOTS)
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_form_farm, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        ViewCompat.setOnApplyWindowInsetsListener(view) { v, insets ->
            val imeInsets = insets.getInsets(WindowInsetsCompat.Type.ime())
            val bottomPadding = imeInsets.bottom - 180
            v.setPadding(v.paddingLeft, v.paddingTop, v.paddingRight, bottomPadding)
            WindowInsetsCompat.CONSUMED
        }

        val txtCityId = view.findViewById<AutoCompleteTextView>(R.id.txtCityId)
        val txtUserId = view.findViewById<AutoCompleteTextView>(R.id.txtUserId)
        val txtCropId = view.findViewById<MultiAutoCompleteTextView>(R.id.txtCropId)
        val txtFarmName = view.findViewById<EditText>(R.id.txtName)
        val txtDimension = view.findViewById<EditText>(R.id.txtDimension)
        val txtAddress = view.findViewById<EditText>(R.id.txtAddress)
        txtHectareas = view.findViewById(R.id.txtHectarea)
        val btnGuardar = view.findViewById<Button>(R.id.btnCrear)
        val btnActualizar: Button = view.findViewById(R.id.btnActualizar)
        val btnEliminar: Button = view.findViewById(R.id.btnEliminar)
        val btnVolver = view.findViewById<ImageButton>(R.id.btnVolver)

        if (lots != null && lots!!.isNotEmpty()) {
            txtHectareas.setText(lots!![0].numHectareas.toString())
        }


        cargar_citys { cityList, cityMap ->
            val cityAdapter: ArrayAdapter<String> = ArrayAdapter(
                requireContext(),
                android.R.layout.simple_dropdown_item_1line,
                cityList
            )
            txtCityId.setAdapter(cityAdapter)
            if(farm != null){
                val city = cityIdMap.filterValues { it == farm!!.CityId }.keys.firstOrNull()
                txtCityId.setText(city)
            }

            txtCityId.setOnItemClickListener { parent, _, position, _ ->
                val citySelected = parent.getItemAtPosition(position) as String
                cityId = cityMap[citySelected]
            }
        }

        cargar_users { userList, userMap ->
            val userAdapter: ArrayAdapter<String> = ArrayAdapter(
                requireContext(),
                android.R.layout.simple_dropdown_item_1line,
                userList
            )
            txtUserId.setAdapter(userAdapter)
            if(farm != null){
                val user = userIdMap.filterValues { it == farm!!.UserId }.keys.firstOrNull()
                txtUserId.setText(user)
            }
            txtUserId.setOnItemClickListener { parent, _, position, _ ->
                val userSelected = parent.getItemAtPosition(position) as String
                userId = userMap[userSelected]
            }
        }

        cargar_crops { cropList, cropMap ->
            val cropAdapter: ArrayAdapter<String> = ArrayAdapter(
                requireContext(),
                android.R.layout.simple_dropdown_item_1line,
                cropList
            )
            txtCropId.setAdapter(cropAdapter)
            txtCropId.setTokenizer(MultiAutoCompleteTextView.CommaTokenizer())
            txtCropId.setOnItemClickListener { parent, _, position, _ ->
                val cropSelected = parent.getItemAtPosition(position) as String
                val cropId = cropMap[cropSelected]

                if (cropId != null && !selectedCropIds.contains(cropId)) {
                    selectedCropIds.add(cropId)
                }
            }

            lots?.let { lotList ->
                selectedCropIds = lotList.map { it.CropId }.toMutableList()
                val selectedCrops = selectedCropIds.map { cropIdMap.filterValues { id -> id == it }.keys.firstOrNull() }.joinToString(", ")
                txtCropId.setText(selectedCrops)
            }

            txtCropId.addTextChangedListener(object : TextWatcher {
                override fun beforeTextChanged(s: CharSequence?, start: Int, count: Int, after: Int) {}

                override fun onTextChanged(s: CharSequence?, start: Int, before: Int, count: Int) {
                    val currentSelectedCrops = s.toString().split(",").map { it.trim() }

                    val iterator = selectedCropIds.iterator()
                    while (iterator.hasNext()) {
                        val cropId = iterator.next()
                        val cropName = cropMap.entries.find { it.value == cropId }?.key
                        if (cropName != null && !currentSelectedCrops.contains(cropName)) {
                            iterator.remove() // Eliminar el cropId de selectedCropIds
                        }
                    }
                }

                override fun afterTextChanged(s: Editable?) {}
            })
        }

        if (farm != null) {
            txtFarmName.setText(farm!!.Name)
            txtDimension.setText(farm!!.Dimension.toString())
            txtAddress.setText(farm!!.Addres)
            cityId = farm!!.CityId
            userId = farm!!.UserId
            val selectedCrops = selectedCropIds.map { cropIdMap.filterValues { id -> id == it }.keys.firstOrNull() }.joinToString(", ")
            txtCropId.setText(selectedCrops)


            btnGuardar.visibility = View.GONE
            btnActualizar.visibility = View.VISIBLE
            btnEliminar.visibility = View.VISIBLE
        }else{
            btnGuardar.visibility = View.VISIBLE
            btnActualizar.visibility = View.GONE
            btnEliminar.visibility = View.GONE
        }

        btnGuardar.setOnClickListener {
            val Name = txtFarmName.text.toString()
            val Address = view.findViewById<EditText>(R.id.txtAddress).text.toString()
            val dimension = txtDimension.text.toString().toInt()

            if (Name.isEmpty() || Address.isEmpty() || cityId == null || userId == null || selectedCropIds.isEmpty()) {
                Toast.makeText(requireContext(), "Por favor, complete todos los campos", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }

            val newFarm = Farm(
                farm?.Id ?: 0,
                Name,
                cityId!!,
                userId!!,
                Address,
                dimension
            )

            if (farm == null) {
                saveFarm(newFarm, selectedCropIds)
            } else {
                updateFarm(newFarm, selectedCropIds)
            }
        }

        btnActualizar.setOnClickListener {
            if (farm == null) {
                Toast.makeText(requireContext(), "No hay registro para actualizar", Toast.LENGTH_SHORT).show()
            }else{
                val updatedFarm = Farm(
                    farm!!.Id,
                    txtFarmName.text.toString(),
                    cityId!!,
                    userId!!,
                    txtAddress.text.toString(),
                    txtDimension.text.toString().toInt()
                )
                updateFarm(updatedFarm!!, selectedCropIds)
            }
        }

        btnEliminar.setOnClickListener {
            if (farm == null) {
                Toast.makeText(requireContext(), "No hay registro para eliminar", Toast.LENGTH_SHORT).show()
            }else{
                deleteFarm(farm!!)
            }
        }

        btnVolver.setOnClickListener {
            requireActivity().supportFragmentManager.popBackStack()
        }
    }

    private fun saveFarm(farm: Farm, crops: MutableList<Int>) {
        try {
            val lots = JSONArray()
            for (i in 0 until crops.size){
                val lotParams = JSONObject().apply{
                    put("num_hectareas", txtHectareas.text.toString().toInt())
                    put("cropId", crops.get(i))
                }
                lots.put(lotParams)
            }

            val params = JSONObject().apply {
                put("name", farm.Name)
                put("cityId", farm.CityId)
                put("userId", farm.UserId)
                put("addres",farm.Addres)
                put("dimension", farm.Dimension)
                put("lots", lots)
            }

            val request = JsonObjectRequest(
                Request.Method.POST,
                urls.urlFarm,
                params,
                { response ->
                    Toast.makeText(context, "Granja guardada exitosamente", Toast.LENGTH_SHORT).show()
                },
                { error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)

        } catch (error: Exception) {
            Toast.makeText(context, "Error al guardar la granja: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun updateFarm(farm: Farm,  crops: MutableList<Int>) {
        try {
            val lots = JSONArray()
            for (i in 0 until crops.size){
                val lotParams = JSONObject().apply{
                    put("num_hectareas", txtHectareas.text.toString().toInt())
                    put("cropId", crops.get(i))
                }
                lots.put(lotParams)
            }

            val params = JSONObject().apply {
                put("id", farm.Id)
                put("name", farm.Name)
                put("cityId", farm.CityId)
                put("userId", farm.UserId)
                put("addres",farm.Addres)
                put("dimension", farm.Dimension)
                put("lots", lots)
            }

            val request = JsonObjectRequest(
                Request.Method.PUT,
                urls.urlFarm,
                params,
                { response ->
                    Toast.makeText(context, "Granja actualizada exitosamente", Toast.LENGTH_SHORT).show()
                },
                { error ->
                    if (error.networkResponse != null && error.networkResponse.statusCode in 400..599) {
                        Toast.makeText(context, "Error al actualizar la finca: ${error.message}", Toast.LENGTH_SHORT).show()
                    } else {
                        Toast.makeText(context, "Registro actualizado Exitosamente", Toast.LENGTH_SHORT).show()
                    }
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)

        } catch (error: Exception) {
            Toast.makeText(context, "Error al actualizar la granja: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun deleteFarm(farm: Farm) {
        try {
            val request = JsonObjectRequest(
                Request.Method.DELETE,
                "${urls.urlFarm}/${farm.Id}",
                null,
                { response ->
                    Toast.makeText(context, "Registro Eliminado Exitosamente", Toast.LENGTH_SHORT).show()
                },
                { error ->
                    if (error.networkResponse != null && error.networkResponse.statusCode in 400..599) {
                        Toast.makeText(context, "Error al eliminar la finca: ${error.message}", Toast.LENGTH_SHORT).show()
                    } else {
                        Toast.makeText(context, "Registro Eliminado Exitosamente", Toast.LENGTH_SHORT).show()
                    }
                }
            )

            val queue = Volley.newRequestQueue(context)
            queue.add(request)

        } catch (error: Exception) {
            Toast.makeText(context, "Error al eliminar el supplie: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun cargar_citys(onComplete: (List<String>, HashMap<String, Int>) -> Unit) {
        try {
            val request = JsonArrayRequest(
                Request.Method.GET,
                urls.urlCity,
                null,
                { response ->
                    for (i in 0 until response.length()) {
                        val item = response.getJSONObject(i)
                        val id = item.getInt("id")
                        val nombre = item.getString("name")
                        listCitys.add(nombre)
                        cityIdMap[nombre] = id
                    }
                    onComplete(listCitys, cityIdMap)
                },
                { error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        } catch (error: Exception) {
            Toast.makeText(context, "Error al cargar ciudades: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun cargar_users(onComplete: (List<String>, HashMap<String, Int>) -> Unit) {
        try {
            val request = JsonArrayRequest(
                Request.Method.GET,
                urls.urlUser,
                null,
                { response ->
                    for (i in 0 until response.length()) {
                        val item = response.getJSONObject(i)
                        val id = item.getInt("id")
                        val nombre = item.getString("username")
                        listUsers.add(nombre)
                        userIdMap[nombre] = id
                    }
                    onComplete(listUsers, userIdMap)
                },
                { error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        } catch (error: Exception) {
            Toast.makeText(context, "Error al cargar usuarios: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun cargar_crops(onComplete: (List<String>, HashMap<String, Int>) -> Unit) {
        try {
            val request = JsonArrayRequest(
                Request.Method.GET,
                urls.urlCrop,
                null,
                { response ->
                    for (i in 0 until response.length()) {
                        val item = response.getJSONObject(i)
                        val id = item.getInt("id")
                        val nombre = item.getString("name")
                        listCrops.add(nombre)
                        cropIdMap[nombre] = id
                    }
                    onComplete(listCrops, cropIdMap)
                },
                { error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        } catch (error: Exception) {
            Toast.makeText(context, "Error al cargar cultivos: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    companion object {
        const val ARG_FARM = "farm"
        const val ARG_LOTS = "lots"

        @JvmStatic
        fun newInstance(farm: Farm?, lots: MutableList<Lot>? = null) =
            FormFarmFragment().apply {
                arguments = Bundle().apply {
                    putParcelable(ARG_FARM, farm)
                    putParcelableArrayList(ARG_LOTS, lots as ArrayList<Lot>?)
                }
            }
    }
}
