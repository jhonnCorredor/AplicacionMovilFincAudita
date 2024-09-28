package com.sena.fincaudita.ChangePassword

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.sena.fincaudita.R

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER

/**
 * A simple [Fragment] subclass.
 * Use the [changePassword.newInstance] factory method to
 * create an instance of this fragment.
 */
class changePassword : Fragment() {
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
        return inflater.inflate(R.layout.fragment_change_password, container, false)
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

        btnAtras.setOnClickListener {
            val nuevoFragmento = CodePassword.newInstance()
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainerView2, nuevoFragmento)
                .addToBackStack(null)
                .commit()
        }

        btnSiguiente.setOnClickListener {
            val nuevoFragmento = UpdatedPasword.newInstance()
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
         * @return A new instance of fragment changePassword.
         */
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance() =
            changePassword().apply {
                arguments = Bundle().apply {
                }
            }
    }
}