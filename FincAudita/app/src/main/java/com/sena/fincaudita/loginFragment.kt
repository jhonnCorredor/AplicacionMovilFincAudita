package com.sena.fincaudita

import android.content.Context
import android.content.Intent
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.CheckBox
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.android.volley.Request
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.sena.fincaudita.ChangePassword.changePasswordActivity
import com.sena.fincaudita.Config.urls
import com.sena.fincaudita.SignUp.SignUpActivity
import org.json.JSONObject

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER

/**
 * A simple [Fragment] subclass.
 * Use the [loginFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class loginFragment : Fragment() {
    // TODO: Rename and change types of parameters

    private lateinit var checkBox: CheckBox

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_login, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        ViewCompat.setOnApplyWindowInsetsListener(view) { v, insets ->
            val imeInsets = insets.getInsets(WindowInsetsCompat.Type.ime())
            val bottomPadding = imeInsets.bottom - 180
            v.setPadding(v.paddingLeft, v.paddingTop, v.paddingRight, bottomPadding)
            WindowInsetsCompat.CONSUMED
        }

        val txtUser: EditText = view.findViewById(R.id.txtUser)
        val txtPassword: EditText = view.findViewById(R.id.txtPassword)
        val btnLogin: Button = view.findViewById(R.id.btnLogin)

        val txtCambiarContraseña: TextView = view.findViewById(R.id.text_forgot_password)
        val txtCrearCuenta: TextView = view.findViewById(R.id.text_create_account)
        checkBox = view.findViewById(R.id.checkbox_remember)

        txtCambiarContraseña.setOnClickListener{
            val intent = Intent(activity, changePasswordActivity::class.java)
            startActivity(intent)
            activity?.finish()
        }

        txtCrearCuenta.setOnClickListener{
            val intent = Intent(activity, SignUpActivity::class.java)
            startActivity(intent)
            activity?.finish()
        }

        btnLogin.setOnClickListener{
            login(txtUser.text.toString(), txtPassword.text.toString())
        }
    }

    fun login(user: String, password: String) {
        try {
            val params = JSONObject()
            params.put("username", user)
            params.put("password", password)

            val request = JsonObjectRequest(
                Request.Method.POST,
                urls.urlLogin,
                params,
                { response ->
                    val menu = response.getJSONArray("menu")
                    if (menu.length() > 0) {
                        val userObject = menu.getJSONObject(0)
                        val userID = userObject.getInt("userID")

                        val sharedPreferences = activity?.getSharedPreferences("user_prefs", Context.MODE_PRIVATE)
                        val editor = sharedPreferences?.edit()
                        editor?.putInt("user_id", userID)
                        editor?.putBoolean("remember_me",checkBox.isChecked)
                        editor?.apply()

                        Toast.makeText(context, "Inicio de sesión exitoso.", Toast.LENGTH_SHORT).show()
                        val intent = Intent(activity, MenuActivity::class.java)
                        startActivity(intent)
                        activity?.finish()
                    }
                },
                { error ->
                    Toast.makeText(context, "Error al iniciar sesión: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )

            val queue = Volley.newRequestQueue(this.context)
            queue.add(request)

        } catch (error: Exception) {
            Toast.makeText(context, "Error al iniciar sesión: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    companion object {
        /**
         * Use this factory method to create a new instance of
         * this fragment using the provided parameters.
         *
         * @param param1 Parameter 1.
         * @param param2 Parameter 2.
         * @return A new instance of fragment loginFragment.
         */
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance() =
            loginFragment().apply {
                arguments = Bundle().apply {
                }
            }
    }
}