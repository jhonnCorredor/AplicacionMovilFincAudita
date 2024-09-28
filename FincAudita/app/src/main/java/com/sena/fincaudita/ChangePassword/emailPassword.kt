package com.sena.fincaudita.ChangePassword

import android.content.Intent
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.sena.fincaudita.MainActivity
import com.sena.fincaudita.R

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER

/**
 * A simple [Fragment] subclass.
 * Use the [emailPassword.newInstance] factory method to
 * create an instance of this fragment.
 */
class emailPassword : Fragment() {
    // TODO: Rename and change types of parameters

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
        val view = inflater.inflate(R.layout.fragment_email_password, container, false)

        return view
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        ViewCompat.setOnApplyWindowInsetsListener(view) { v, insets ->
            val imeInsets = insets.getInsets(WindowInsetsCompat.Type.ime())
            val bottomPadding = imeInsets.bottom - 180
            v.setPadding(v.paddingLeft, v.paddingTop, v.paddingRight, bottomPadding)
            WindowInsetsCompat.CONSUMED
        }

        val btnSiguiente: Button = view.findViewById(R.id.btnSiguiente)

        val btnAtras: Button = view.findViewById(R.id.btnAtras)

        btnAtras.setOnClickListener {
            //requireActivity().supportFragmentManager.popBackStack()
            val intent = Intent(activity, MainActivity::class.java)
            startActivity(intent)
            activity?.finish()
        }

        btnSiguiente.setOnClickListener {
            val nuevoFragmento = CodePassword.newInstance()
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainerView2, nuevoFragmento)
                .addToBackStack(null)
                .commit()
        }

    }

    companion object {
        /**
         * Use this factory method to create a new instance of
         * this fragment using the provided parameters.
         *
         * @param param1 Parameter 1.
         * @param param2 Parameter 2.
         * @return A new instance of fragment emailPassword.
         */
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance() =
            emailPassword().apply {
                arguments = Bundle().apply {
                }
            }
    }
}