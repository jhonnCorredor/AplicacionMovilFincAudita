package com.sena.fincaudita.Supplie

import GenericAdapter
import android.annotation.SuppressLint
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
import com.sena.fincaudita.Entity.Supplie
import com.sena.fincaudita.R

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER

/**
 * A simple [Fragment] subclass.
 * Use the [SupplieFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class SupplieFragment : Fragment() {
    // TODO: Rename and change types of parameters

    private var supplies = mutableListOf<Supplie>()
    private lateinit var adapter: GenericAdapter<Supplie>

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
        return inflater.inflate(R.layout.fragment_supplie, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val recyclerView: RecyclerView = view.findViewById(R.id.listSupplies)

        val btnCambiarFragment: ImageButton = view.findViewById(R.id.btnCambiarFragmento)
        btnCambiarFragment.setOnClickListener {
            requireActivity().supportFragmentManager.beginTransaction()
                .replace(R.id.fragment_container, FormSupplieFragment.newInstance(null))
                .addToBackStack(null)
                .commit()
        }
        val btnVolver: ImageButton = view.findViewById(R.id.btnVolver)
        btnVolver.setOnClickListener {
            requireActivity().supportFragmentManager.popBackStack()
        }

        recyclerView.layoutManager = LinearLayoutManager(context)

        adapter = GenericAdapter(
            items = supplies,
            layoutResId = R.layout.item_recycler,
            bindView = { view, supplie ->
                val name: TextView = view.findViewById(R.id.title1)
                val price: TextView = view.findViewById(R.id.title2)
                val description: TextView = view.findViewById(R.id.subtitle1)
                val code: TextView = view.findViewById(R.id.code)
                val icon: ImageView = view.findViewById(R.id.icon)
                val Edit: ImageView = view.findViewById(R.id.detail_icon)

                name.text = supplie.Name
                price.text = supplie.Price.toString() + "$"
                description.text = supplie.Description
                code.text = supplie.Code
                icon.setImageResource(R.drawable.supplies)

                Edit.setOnClickListener{
                    cargar_supplieId(supplie.Id)
                }
            }
        )
        recyclerView.adapter = adapter
        cargar_supplies()
    }

    private fun cargar_supplies() {
        try {
            val request = JsonArrayRequest(
                Request.Method.GET,
                urls.urlSupplies,
                null,
                { response ->
                    supplies.clear()
                    for (i in 0 until response.length()) {
                        val item = response.getJSONObject(i)
                        val supplie = Supplie(
                            Id = item.getInt("id"),
                            Name = item.getString("name"),
                            Description = item.getString("description"),
                            Code = item.getString("code"),
                            Price = item.getDouble("price")
                        )
                        supplies.add(supplie)
                    }
                    adapter.updateData(supplies)
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

    private fun cargar_supplieId(id: Int) {
        try {
            val request = JsonObjectRequest(
                Request.Method.GET,
                "${urls.urlSupplies}/${id}",
                null,
                { response ->
                    val supplie = Supplie(
                        Id = response.getInt("id"),
                        Name = response.getString("name"),
                        Description = response.getString("description"),
                        Code = response.getString("code"),
                        Price = response.getDouble("price")
                    )

                    val formSupplieFragment = FormSupplieFragment.newInstance(supplie)
                    requireActivity().supportFragmentManager.beginTransaction()
                        .replace(R.id.fragment_container, formSupplieFragment)
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

    companion object {
        /**
         * Use this factory method to create a new instance of
         * this fragment using the provided parameters.
         *
         * @param param1 Parameter 1.
         * @param param2 Parameter 2.
         * @return A new instance of fragment SupplieFragment.
         */
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance() =
            SupplieFragment().apply {
                arguments = Bundle().apply {
                }
            }
    }
}