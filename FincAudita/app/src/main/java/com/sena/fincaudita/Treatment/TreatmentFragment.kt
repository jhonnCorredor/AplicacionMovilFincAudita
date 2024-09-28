package com.sena.fincaudita.Treatment

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
import com.sena.fincaudita.Entity.LotTreatment
import com.sena.fincaudita.Entity.SupplieTreatment
import com.sena.fincaudita.Entity.Treatment
import com.sena.fincaudita.R

class TreatmentFragment : Fragment() {

    private lateinit var adapter: GenericAdapter<Treatment>
    private var treatments = mutableListOf<Treatment>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.fragment_treatment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val recyclerView: RecyclerView = view.findViewById(R.id.listTreatment)

        val btnVolver: ImageButton = view.findViewById(R.id.btnVolver)
        btnVolver.setOnClickListener {
            requireActivity().supportFragmentManager.popBackStack()
        }

        val btnSiguiente: ImageButton = view.findViewById(R.id.btnCambiarFragmento)
        btnSiguiente.setOnClickListener {
            val formTreatmentFragment = FormTreatmentFragment.newInstance(null)
            requireActivity().supportFragmentManager.beginTransaction()
                .replace(R.id.fragment_container, formTreatmentFragment)
                .addToBackStack(null)
                .commit()
        }

        recyclerView.layoutManager = LinearLayoutManager(context)
        adapter = GenericAdapter(
            items = treatments,
            layoutResId = R.layout.item_recycler,
            bindView = { view, treatment ->
                val fecha: TextView = view.findViewById(R.id.title1)
                val type: TextView = view.findViewById(R.id.subtitle1)
                val supplie: TextView = view.findViewById(R.id.additional_info)
                val icon: ImageView = view.findViewById(R.id.icon)
                val Edit: ImageView = view.findViewById(R.id.detail_icon)

                fecha.text = treatment.dateTreatment
                type.text = treatment.typeTreatment
                val supplieNames = treatment.supplieList.joinToString { it.supplie }
                supplie.text = supplieNames

                icon.setImageResource(R.drawable.fertilizer)


                Edit.setOnClickListener {
                    cargar_treatmentId(treatment.id)
                }
            }
        )
        recyclerView.adapter = adapter
        cargar_treatments()
    }

    private fun cargar_treatments(){
        try{
            val request = JsonArrayRequest(
                Request.Method.GET,
                urls.urlTreatment,
                null,
                { response ->
                    treatments.clear()
                    for (i in 0 until response.length()) {
                        val item = response.getJSONObject(i)
                        val lotArray = item.optJSONArray("lotList")
                        val lots = mutableListOf<LotTreatment>()
                        if(lotArray != null){
                            for (j in 0 until lotArray.length()) {
                                val lotItem = lotArray.getJSONObject(j)
                                lots.add(
                                    LotTreatment(
                                        lotItem.getInt("id"),
                                        lotItem.getInt("lotId"),
                                        lotItem.getString("lot")
                                    )
                                )
                            }
                        }


                        val suppliArray = item.optJSONArray("supplieList")
                        val supplies = mutableListOf<SupplieTreatment>()
                        if (suppliArray != null){
                            for (j in 0 until suppliArray.length()) {
                                val suppliItem = suppliArray.getJSONObject(j)
                                supplies.add(
                                    SupplieTreatment(
                                        suppliItem.getInt("id"),
                                        suppliItem.getString("dose"),
                                        suppliItem.getInt("suppliesId"),
                                        suppliItem.getString("supplie"),
                                    )
                                )
                            }
                        }

                        treatments.add(
                            Treatment(
                                item.getInt("id"),
                                item.getString("dateTreatment"),
                                item.getString("typeTreatment"),
                                item.getString("quantityMix"),
                                lots,
                                supplies
                            )
                        )
                    }
                    adapter.updateData(treatments)
                    adapter.notifyDataSetChanged()
                },{ error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        }catch (error: Exception){
            Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }

    private fun cargar_treatmentId(id: Int){
        try{
            val request = JsonObjectRequest(
                Request.Method.GET,
                "${urls.urlTreatment}/${id}",
                null,
                { response ->
                    val lotArray = response.optJSONArray("lotList")
                    val lots = mutableListOf<LotTreatment>()
                    if(lotArray != null){
                        for (j in 0 until lotArray.length()) {
                            val lotItem = lotArray.getJSONObject(j)
                            lots.add(
                                LotTreatment(
                                    lotItem.getInt("id"),
                                    lotItem.getInt("lotId"),
                                    lotItem.getString("lot")
                                )
                            )
                        }
                    }

                    val suppliArray = response.optJSONArray("supplieList")
                    val supplies = mutableListOf<SupplieTreatment>()
                    if (suppliArray != null){
                        for (j in 0 until suppliArray.length()) {
                            val suppliItem = suppliArray.getJSONObject(j)
                            supplies.add(
                                SupplieTreatment(
                                    suppliItem.getInt("id"),
                                    suppliItem.getString("dose"),
                                    suppliItem.getInt("suppliesId"),
                                    suppliItem.getString("supplie"),
                                )
                            )
                        }
                    }

                    val treatment = Treatment(
                        response.getInt("id"),
                        response.getString("dateTreatment"),
                        response.getString("typeTreatment"),
                        response.getString("quantityMix"),
                        lots,
                        supplies
                    )
                    val formTreatmentFragment = FormTreatmentFragment.newInstance(treatment)
                    requireActivity().supportFragmentManager.beginTransaction()
                        .replace(R.id.fragment_container, formTreatmentFragment)
                        .addToBackStack(null)
                        .commit()
                }
                ,{ error ->
                    Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
                }
            )
            val queue = Volley.newRequestQueue(context)
            queue.add(request)
        }catch (error: Exception){
            Toast.makeText(context, "Error: ${error.message}", Toast.LENGTH_SHORT).show()
        }
    }


    companion object {
        @JvmStatic
        fun newInstance() =
            TreatmentFragment().apply {
                arguments = Bundle().apply {
                }
            }
    }
}