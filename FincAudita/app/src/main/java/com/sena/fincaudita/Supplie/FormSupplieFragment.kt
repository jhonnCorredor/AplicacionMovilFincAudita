package com.sena.fincaudita.Supplie

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.ImageButton
import android.widget.TextView
import android.widget.Toast
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.android.volley.Request
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.sena.fincaudita.Config.urls
import com.sena.fincaudita.Entity.Supplie
import com.sena.fincaudita.R
import org.json.JSONObject

private const val ARG_SUPPLIE = "supplie"

class FormSupplieFragment : Fragment() {

    private var supplie: Supplie? = null


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {
            supplie = it.getParcelable(ARG_SUPPLIE)
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_form_supplie, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        ViewCompat.setOnApplyWindowInsetsListener(view) { v, insets ->
            val imeInsets = insets.getInsets(WindowInsetsCompat.Type.ime())
            val bottomPadding = imeInsets.bottom - 180
            v.setPadding(v.paddingLeft, v.paddingTop, v.paddingRight, bottomPadding)
            WindowInsetsCompat.CONSUMED
        }

        val txtCode: TextView = view.findViewById(R.id.txtCode)
        val txtNombreProducto: TextView = view.findViewById(R.id.txtNombreProducto)
        val txtDescripcion: TextView = view.findViewById(R.id.txtDescripcion)
        val txtPrecio: TextView = view.findViewById(R.id.txtPrecio)
        val btnCrear: Button = view.findViewById(R.id.btnCrear)
        val btnActualizar: Button = view.findViewById(R.id.btnActualizar)
        val btnEliminar: Button = view.findViewById(R.id.btnEliminar)
        val btnVolver: ImageButton = view.findViewById(R.id.btnVolver)

        if (supplie != null) {
            txtCode.text = supplie!!.Code
            txtNombreProducto.text = supplie!!.Name
            txtDescripcion.text = supplie!!.Description
            txtPrecio.text = supplie!!.Price.toString()
            btnCrear.visibility = View.GONE
            btnActualizar.visibility = View.VISIBLE
            btnEliminar.visibility = View.VISIBLE
        } else {
            btnCrear.visibility = View.VISIBLE
            btnActualizar.visibility = View.GONE
            btnEliminar.visibility = View.GONE
        }

        btnCrear.setOnClickListener {
            val code = txtCode.text.toString()
            val nombreProducto = txtNombreProducto.text.toString()
            val descripcion = txtDescripcion.text.toString()
            val precioStr = txtPrecio.text.toString()
            if (code.isEmpty() || nombreProducto.isEmpty() || descripcion.isEmpty() || precioStr.isEmpty()) {
                Toast.makeText(requireContext(), "Por favor, complete todos los campos", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            val precio = try {
                precioStr.toDouble()
            } catch (e: NumberFormatException) {
                Toast.makeText(requireContext(), "El precio debe ser un número válido", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            val newSupplie = Supplie(
                0,
                nombreProducto,
                descripcion,
                code,
                precio
            )
            saveSupplie(newSupplie)
        }

        btnActualizar.setOnClickListener {
            val code = txtCode.text.toString()
            val nombreProducto = txtNombreProducto.text.toString()
            val descripcion = txtDescripcion.text.toString()
            val precioStr = txtPrecio.text.toString()
            if (code.isEmpty() || nombreProducto.isEmpty() || descripcion.isEmpty() || precioStr.isEmpty()) {
                Toast.makeText(requireContext(), "Por favor, complete todos los campos", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            val precio = try {
                precioStr.toDouble()
            } catch (e: NumberFormatException) {
                Toast.makeText(requireContext(), "El precio debe ser un número válido", Toast.LENGTH_SHORT).show()
                return@setOnClickListener
            }
            val updatedSupplie = supplie?.copy(
                Name = nombreProducto,
                Description = descripcion,
                Price = precio,
                Code = code
            )
            if (updatedSupplie != null) {
                updateSupplie(updatedSupplie)
            }
        }

        btnEliminar.setOnClickListener {
            supplie?.let {
                deleteSupplie(it)
            }
        }

        btnVolver.setOnClickListener {
            requireActivity().supportFragmentManager.popBackStack()
        }
    }

    private fun saveSupplie(supplie: Supplie) {
        try {
            val params = JSONObject()
            params.put("name", supplie.Name)
            params.put("description", supplie.Description)
            params.put("price", supplie.Price)
            params.put("code", supplie.Code)

            val request = JsonObjectRequest(
                Request.Method.POST,
                urls.urlSupplies,
                params,
                { response ->
                    Toast.makeText(context, "Registro Guardado Exitosamente", Toast.LENGTH_SHORT).show()
                },
                { error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        } catch (error: Exception) {
            Toast.makeText(context, "Error al guardar el supplie: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun updateSupplie(supplie: Supplie) {
        try {
            val params = JSONObject()
            params.put("id", supplie.Id)
            params.put("name", supplie.Name)
            params.put("description", supplie.Description)
            params.put("price", supplie.Price)
            params.put("code", supplie.Code)

            val request = JsonObjectRequest(
                Request.Method.PUT,
                urls.urlSupplies,
                params,
                { response ->
                    Toast.makeText(context, "Registro Actualizado Exitosamente", Toast.LENGTH_SHORT).show()
                },
                { error ->
                    if (error.networkResponse != null && error.networkResponse.statusCode in 400..599) {
                        Toast.makeText(context, "Error al actualizar el supplie: ${error.message}", Toast.LENGTH_SHORT).show()
                    } else {
                        Toast.makeText(context, "Registro Actualizado Exitosamente", Toast.LENGTH_SHORT).show()
                    }
                }
            )

            val queue = Volley.newRequestQueue(context)
            queue.add(request)

        } catch (error: Exception) {
            Toast.makeText(context, "Error al actualizar el supplie: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun deleteSupplie(supplie: Supplie) {
        try {
            val request = JsonObjectRequest(
                Request.Method.DELETE,
                "${urls.urlSupplies}/${supplie.Id}",
                null,
                { response ->
                    Toast.makeText(context, "Registro Eliminado Exitosamente", Toast.LENGTH_SHORT).show()
                },
                { error ->
                    if (error.networkResponse != null && error.networkResponse.statusCode in 400..599) {
                        Toast.makeText(context, "Error al eliminar el supplie: ${error.message}", Toast.LENGTH_SHORT).show()
                    } else {
                        // Manejo de errores no relacionados con la red
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

    companion object {
        private const val ARG_SUPPLIE = "supplie"

        @JvmStatic
        fun newInstance(supplie: Supplie?) =
            FormSupplieFragment().apply {
                arguments = Bundle().apply {
                    putParcelable(ARG_SUPPLIE, supplie)
                }
            }
    }
}
