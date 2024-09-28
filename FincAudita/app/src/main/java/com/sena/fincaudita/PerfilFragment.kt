package com.sena.fincaudita

import android.content.Context
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.android.volley.Request
import android.widget.Button
import android.widget.EditText
import android.widget.ImageButton
import android.widget.TextView
import com.android.volley.toolbox.JsonObjectRequest
import android.widget.Toast
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.fragment.app.FragmentTransaction
import com.android.volley.toolbox.Volley
import com.sena.fincaudita.Config.urls
import com.sena.fincaudita.Entity.User
import org.json.JSONArray
import org.json.JSONObject

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER

/**
 * A simple [Fragment] subclass.
 * Use the [PerfilFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class PerfilFragment : Fragment() {
    // TODO: Rename and change types of parameters
    private lateinit var etxUser: TextView
    private lateinit var txtUsername: EditText
    private lateinit var txtPassword: EditText
    private lateinit var userLogged: User

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
        return inflater.inflate(R.layout.fragment_perfil, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        ViewCompat.setOnApplyWindowInsetsListener(view) { v, insets ->
            val imeInsets = insets.getInsets(WindowInsetsCompat.Type.ime())
            val bottomPadding = imeInsets.bottom - 180
            v.setPadding(v.paddingLeft, v.paddingTop, v.paddingRight, bottomPadding)
            WindowInsetsCompat.CONSUMED
        }

        etxUser = view.findViewById(R.id.textView14)
        txtUsername = view.findViewById(R.id.txtNombre)
        txtPassword = view.findViewById(R.id.txtPassword)
        val btnActualizar: Button = view.findViewById(R.id.btnActualizar)

        loadUser()

        btnActualizar.setOnClickListener {
            val username = txtUsername.text.toString()
            val password = txtPassword.text.toString()
            userLogged.Username = username;
            userLogged.Password = password;
            updateUser(userLogged)
        }

        val btnVolver: ImageButton = view.findViewById(R.id.btnVolver)
        btnVolver.setOnClickListener {
            val transaction = parentFragmentManager.beginTransaction()
            transaction.replace(R.id.fragment_container, HomeFragment.newInstance())
            transaction.addToBackStack(null)
            transaction.setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
            transaction.commit()
        }
    }

    private fun loadUser(){
        val sharedPreferences = activity?.getSharedPreferences("user_prefs", Context.MODE_PRIVATE)
        val userID = sharedPreferences?.getInt("user_id", -1)
        if (userID != -1) {
            try {
            val request = JsonObjectRequest(
                Request.Method.GET,
                "${urls.urlUser}/$userID",
                null,
                { response ->
                    val username = response.getString("username")
                    etxUser.text = username
                    txtUsername.setText(username)
                    txtPassword.setText(response.getString("password"))
                    userLogged = User(
                        response.getInt("id"),
                        response.getString("username"),
                        response.getString("password"),
                        response.getInt("personId"))
                },{error ->
                    Toast.makeText(context, "Error al cargar el usuario: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
                val queue = Volley.newRequestQueue(context)
                queue.add(request)
            }catch (error: Exception){
                Toast.makeText(context, "Error al cargar el usuario: ${error.message}", Toast.LENGTH_SHORT).show()
            }
        }
    }

    private fun updateUser(user: User) {
        try {
            val params = JSONObject().apply {
                put("username", user.Username)
                put("password", user.Password)
                put("personId", user.PersonId)
                put("id", user.Id)
                val role = JSONObject().apply {
                    put("id", 1)
                }
                val rolesArray = JSONArray().apply {
                    put(role)
                }
                put("roles", rolesArray)
            }

            val request = JsonObjectRequest(
                Request.Method.PUT,
                urls.urlUser,
                params,
                { response ->
                    if (response == null || response.length() == 0) {
                        Toast.makeText(context, "Datos actualizados exitosamente", Toast.LENGTH_SHORT).show()
                    } else {
                        Toast.makeText(context, "Datos actualizados exitosamente", Toast.LENGTH_SHORT).show()
                    }
                },
                { error ->
                    if (error.networkResponse != null && error.networkResponse.statusCode in 400..599) {
                        Toast.makeText(context, "Error al actualizar los datos: ${error.message}", Toast.LENGTH_SHORT).show()
                    } else {
                        // Manejo de errores no relacionados con la red
                        Toast.makeText(context, "Datos actualizados exitosamente", Toast.LENGTH_SHORT).show()
                    }
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        } catch (error: Exception) {
            error.printStackTrace()
            Toast.makeText(context, "Error al cargar el usuario: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }


    companion object {
        /**
         * Use this factory method to create a new instance of
         * this fragment using the provided parameters.
         *
         * @param param1 Parameter 1.
         * @param param2 Parameter 2.
         * @return A new instance of fragment PerfilFragment.
         */
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance() =
            PerfilFragment().apply {
                arguments = Bundle().apply {
                }
            }
    }
}