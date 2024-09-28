package com.sena.fincaudita.Farm

import GenericAdapter
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageButton
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.android.volley.Request
import com.android.volley.toolbox.JsonArrayRequest
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.sena.fincaudita.Config.urls
import com.sena.fincaudita.Entity.Farm
import com.sena.fincaudita.Entity.Lot
import com.sena.fincaudita.R

class FarmFragment : Fragment() {

    private lateinit var adapter: GenericAdapter<Farm>
    private var farms = mutableListOf<Farm>()
    private var mapFarms = HashMap<Farm,MutableList<Lot>>()
    private var cropIdMap = HashMap<Int, String>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_farm, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val recyclerView: RecyclerView = view.findViewById(R.id.listFarms)

        val btnSiguiente: ImageButton = view.findViewById(R.id.btnCambiarFragmento)
        btnSiguiente.setOnClickListener{
            requireActivity().supportFragmentManager.beginTransaction()
                .replace(R.id.fragment_container, FormFarmFragment())
                .addToBackStack(null)
                .commit()
        }

        val btnVolver: ImageButton = view.findViewById(R.id.btnVolver)
        btnVolver.setOnClickListener {
            requireActivity().supportFragmentManager.popBackStack()
        }

        recyclerView.layoutManager = LinearLayoutManager(context)

        adapter = GenericAdapter(
            items = farms,
            layoutResId = R.layout.item_recycler,
            bindView = { view, farm ->
                val nombre: TextView = view.findViewById(R.id.title1)
                val cultivos: TextView = view.findViewById(R.id.subtitle1)
                val icon: ImageView = view.findViewById(R.id.icon)
                val Edit: ImageView = view.findViewById(R.id.detail_icon)
                val lotes = mapFarms[farm]
                var cultivo = lotes?.map { it.Cultivo }?.joinToString(", ")

                nombre.text = farm.Name
                icon.setImageResource(R.drawable.farm)
                cultivos.text = cultivo

                Edit.setOnClickListener {
                    cargar_farmId(farm.Id)
                }
            }
        )
        recyclerView.adapter = adapter
        cargar_farms()
        cargar_crops()
    }

    // Función para cargar las granjas
    private fun cargar_farms() {
        try {
            val request = JsonArrayRequest(
                Request.Method.GET,
                urls.urlFarm,
                null,
                { response ->
                    farms.clear()
                    for (i in 0 until response.length()) {
                        val item = response.getJSONObject(i)
                        var lotes = mutableListOf<Lot>()
                        val lots = item.getJSONArray("lots")
                        for(a in 0 until lots.length()){
                            val lotItem = lots.getJSONObject(a)
                            val lot =  Lot (
                                Id = lotItem.getInt("id"),
                                CropId = lotItem.getInt("cropId"),
                                numHectareas = lotItem.getInt("num_hectareas"),
                                Cultivo = lotItem.getString("cultivo")
                            )
                            lotes.add(lot)
                        }

                        val farm = Farm(
                            Id = item.getInt("id"),
                            Name = item.getString("name"),
                            CityId = item.getInt("cityId"),
                            UserId = item.getInt("userId"),
                            Addres = item.getString("addres"),
                            Dimension = item.getInt("dimension"),
                        )
                        farms.add(farm)
                        mapFarms[farm] = lotes
                    }
                    adapter.updateData(farms)
                    adapter.notifyDataSetChanged()
                },
                { error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        } catch (error: Exception) {
            Toast.makeText(
                context,
                "Error al cargar data: ${error.message}",
                Toast.LENGTH_SHORT
            ).show()
        }
    }

    private fun cargar_farmId(id: Int) {
        try {
            val request = JsonObjectRequest(
                Request.Method.GET,
                "${urls.urlFarm}/${id}",
                null,
                { response ->
                        val farm = Farm(
                            Id = response.getInt("id"),
                            Name = response.getString("name"),
                            CityId = response.getInt("cityId"),
                            UserId = response.getInt("userId"),
                            Addres = response.getString("addres"),
                            Dimension = response.getInt("dimension"),
                        )

                        val CropId = mapFarms[farm]

                    val formFarmFragment = FormFarmFragment.newInstance(farm, CropId)
                    requireActivity().supportFragmentManager.beginTransaction()
                        .replace(R.id.fragment_container, formFarmFragment)
                        .addToBackStack(null)
                        .commit()
                },
                { error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        } catch (error: Exception) {
            Toast.makeText(
                context,
                "Error al cargar data: ${error.message}",
                Toast.LENGTH_SHORT
            ).show()
        }
    }

    // Función para cargar los nombres de los cultivos
    private fun cargar_crops() {
        try {
            val request = JsonArrayRequest(
                Request.Method.GET,
                urls.urlCrop,
                null,
                { response ->
                    cropIdMap.clear()
                    for (i in 0 until response.length()) {
                        val item = response.getJSONObject(i)
                        val cropId = item.getInt("id")
                        val cropName = item.getString("name")
                        cropIdMap[cropId] = cropName
                    }
                },
                { error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        } catch (error: Exception) {
            Toast.makeText(
                context,
                "Error al cargar cultivos: ${error.message}",
                Toast.LENGTH_SHORT
            ).show()
        }
    }

    companion object {
        @JvmStatic
        fun newInstance() =
            FarmFragment().apply {
                arguments = Bundle().apply {
                }
            }
    }
}
