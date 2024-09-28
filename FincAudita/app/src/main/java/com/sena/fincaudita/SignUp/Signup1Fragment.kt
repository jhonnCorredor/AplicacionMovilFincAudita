package com.sena.fincaudita.SignUp

import android.content.Intent
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.AutoCompleteTextView
import android.widget.Button
import android.widget.CheckBox
import android.widget.EditText
import android.widget.Spinner
import android.widget.TextView
import android.widget.Toast
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.android.volley.Request
import com.android.volley.toolbox.JsonArrayRequest
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.sena.fincaudita.Config.urls
import com.sena.fincaudita.Entity.Person
import com.sena.fincaudita.Entity.User
import com.sena.fincaudita.MainActivity
import com.sena.fincaudita.R
import com.sena.fincaudita.components.DatePickerFragment
import org.json.JSONArray
import org.json.JSONObject
import java.text.SimpleDateFormat
import java.util.Locale

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER

/**
 * A simple [Fragment] subclass.
 * Use the [Signup1Fragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class Signup1Fragment : Fragment() {
    // TODO: Rename and change types of parameters
    private var listCitys = mutableListOf<String>()
    private var cityIdMap = HashMap<String, Int>()
    private var cityId: Int? = null
    private lateinit var checbox: CheckBox

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_signup1, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        ViewCompat.setOnApplyWindowInsetsListener(view) { v, insets ->
            val imeInsets = insets.getInsets(WindowInsetsCompat.Type.ime())
            val bottomPadding = imeInsets.bottom - 180
            v.setPadding(v.paddingLeft, v.paddingTop, v.paddingRight, bottomPadding)
            WindowInsetsCompat.CONSUMED
        }

        val btnAtras: Button = view.findViewById(R.id.btnAtras)
        val btnSiguiente: Button = view.findViewById(R.id.btnSiguiente)
        val txtSingIn: TextView = view.findViewById(R.id.txtSignIn)
        val txtNombre: EditText = view.findViewById(R.id.txtNombre)
        val txtApellido: EditText = view.findViewById(R.id.txtApellido)
        val txtTipoDocumento: Spinner = view.findViewById(R.id.txtTipoDocumento)
        val txtNumeroDocumento: EditText = view.findViewById(R.id.txtNumeroDocumento)
        val txtFechaNacimiento: EditText = view.findViewById(R.id.txtFechaNacimiento)
        val txtTelefono: EditText = view.findViewById(R.id.txtTelefono)
        val txtCorreo: EditText = view.findViewById(R.id.txtCorreo)
        val txtDireccion: EditText = view.findViewById(R.id.txtDireccion)
        val txtCiudad: AutoCompleteTextView = view.findViewById(R.id.txtCiudad)
        val txtNombreUsuario: EditText = view.findViewById(R.id.txtNombreUsuario)
        val txtContrasena: EditText = view.findViewById(R.id.txtPassword)
        checbox = view.findViewById(R.id.checkbox_remember)

        btnAtras.setOnClickListener {
            val intent = Intent(activity, MainActivity::class.java)
            startActivity(intent)
            activity?.finish()
        }

        txtFechaNacimiento.setOnClickListener {
            showDatePickerDialog(txtFechaNacimiento)
        }

        btnSiguiente.setOnClickListener {
            if (validarCampos(txtNombre, txtApellido, txtNumeroDocumento, txtFechaNacimiento, txtTelefono, txtCorreo, txtDireccion, txtCiudad, txtNombreUsuario, txtContrasena, checbox)) {
                /*val nuevoFragmento = Signup2Fragment.newInstance()
                parentFragmentManager.beginTransaction()
                    .replace(R.id.fragmentContainerView2, nuevoFragmento)
                    .addToBackStack(null)
                    .commit()*/
                val typeDocument = txtTipoDocumento.selectedItemId.toInt()
                var type = ""
                when (typeDocument) {
                    0 -> type="CC"
                    1 -> type="TI"
                    2 -> type="CE"
                    3 -> type="PS"
                    else -> null
                }
                val person = Person( 0,
                txtNombre.text.toString(),
                txtApellido.text.toString(),
                txtCorreo.text.toString(),
                txtDireccion.text.toString(),
                txtTelefono.text.toString().toLong(),
                type,
                txtNumeroDocumento.text.toString(),
                cityId!!,
                txtFechaNacimiento.text.toString())
                val user = User(0, txtNombreUsuario.text.toString(), txtContrasena.text.toString(), 0)
                guardarPerson(person, user)
            } else {
                Toast.makeText(context, "Por favor completa todos los campos.", Toast.LENGTH_SHORT).show()
            }
        }

        txtSingIn.setOnClickListener {
            val intent = Intent(activity, MainActivity::class.java)
            startActivity(intent)
            activity?.finish()
        }

        cargar_citys { cityList, cityMap ->
            val userAdapter: ArrayAdapter<String> = ArrayAdapter(
                requireContext(),
                android.R.layout.simple_dropdown_item_1line,
                cityList
            )
            txtCiudad.setAdapter(userAdapter)

            txtCiudad.setOnItemClickListener { parent, _, position, _ ->
                val citySelected = parent.getItemAtPosition(position) as String
                cityId = cityMap[citySelected]
            }
        }
    }

    private fun showDatePickerDialog(editText: EditText) {
        val datePicker = DatePickerFragment { day, month, year ->
            onDateSelected(day, month, year, editText)
        }
        datePicker.show(parentFragmentManager, "datapicker")
    }

    private fun onDateSelected(day: Int, month: Int, year: Int, editText: EditText) {
        val formattedDay = if (day < 10) "0$day" else day.toString()
        val formattedMonth = if (month + 1 < 10) "0${month + 1}" else (month + 1).toString()
        editText.setText("$year-$formattedMonth-$formattedDay")
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
            Toast.makeText(context, "Error al cargar usuarios: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun guardarPerson(person: Person, user: User){
        try {
            // Formatear la fecha en el formato requerido
            val originalFormat = SimpleDateFormat("yyyy-MM-dd", Locale.getDefault())
            val targetFormat = SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS'Z'", Locale.getDefault())
            val date = originalFormat.parse(person.Birth_of_date)
            val formattedDate = targetFormat.format(date)

            val params = JSONObject().apply {
                put("first_name", person.First_name)
                put("last_name", person.Last_name)
                put("email", person.Email)
                put("addres", person.Addres)
                put("phone", person.Phone)
                put("type_document", person.Type_document)
                put("document", person.Document)
                put("cityId", person.CityId)
                put("birth_of_date", formattedDate) // Fecha en el nuevo formato
            }
            val request = JsonObjectRequest(
                Request.Method.POST,
                urls.urlPerson,
                params,
                { response ->
                    val result = response
                    val paramsUser = JSONObject().apply {
                        put("username", user.Username)
                        put("password", user.Password)
                        put("personId", response.getInt("id"))
                        val role = JSONObject().apply {
                            put("id", 1) // Aquí pones el id del rol
                        }
                        // Crear el array de roles
                        val rolesArray = JSONArray().apply {
                            put(role)
                        }
                        put("roles", rolesArray)
                    }
                    val requestUser = JsonObjectRequest(
                        Request.Method.POST,
                        urls.urlUser,
                        paramsUser,
                        {response ->
                            Toast.makeText(context, "Registro Guardado Exitosamente", Toast.LENGTH_SHORT).show()
                            val nuevoFragmento = Signup2Fragment.newInstance()
                            parentFragmentManager.beginTransaction()
                                .replace(R.id.fragmentContainerView2, nuevoFragmento)
                                .addToBackStack(null)
                                .commit()
                        }, { error ->
                            val err = error
                            Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                        }
                    )
                    val queue = Volley.newRequestQueue(context)
                    queue.add(requestUser)
                },
                { error ->
                    val err = error
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )

            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        }catch (error: Exception){
            Toast.makeText(context, "Error al crear el usuario: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun validarCampos(
        txtNombre: EditText,
        txtApellido: EditText,
        txtNumeroDocumento: EditText,
        txtFechaNacimiento: EditText,
        txtTelefono: EditText,
        txtCorreo: EditText,
        txtDireccion: EditText,
        txtCiudad: AutoCompleteTextView,
        txtNombreUsuario: EditText,
        txtContrasena: EditText,
        checbox: CheckBox
    ): Boolean {
        return when {
            txtNombre.text.isEmpty() -> false
            txtApellido.text.isEmpty() -> false
            txtNumeroDocumento.text.isEmpty() -> false
            txtFechaNacimiento.text.isEmpty() -> false
            txtTelefono.text.isEmpty() -> false
            txtCorreo.text.isEmpty() -> false
            txtDireccion.text.isEmpty() -> false
            txtCiudad.text.isEmpty() -> false
            txtNombreUsuario.text.isEmpty() -> false
            txtContrasena.text.isEmpty() -> false
            !checbox.isChecked -> {
                Toast.makeText(context, "Debes aceptar los términos y condiciones.", Toast.LENGTH_SHORT).show()
                false
            }
            else -> true
        }
    }



    companion object {
        /**
         * Use this factory method to create a new instance of
         * this fragment using the provided parameters.
         *
         * @param param1 Parameter 1.
         * @param param2 Parameter 2.
         * @return A new instance of fragment Signup1Fragment.
         */
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance() =
            Signup1Fragment().apply {
                arguments = Bundle().apply {
                }
            }
    }
}