package com.sena.fincaudita

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.FragmentTransaction
import com.sena.fincaudita.Farm.FarmFragment
import com.sena.fincaudita.Supplie.SupplieFragment
import com.sena.fincaudita.Treatment.TreatmentFragment
import com.sena.fincaudita.review.RevisionFragment

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER

/**
 * A simple [Fragment] subclass.
 * Use the [HomeFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class HomeFragment : Fragment() {
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
        val view = inflater.inflate(R.layout.fragment_home, container, false)

        val ctnRevision = view.findViewById<ConstraintLayout>(R.id.cntRevision)
        val ctnFarm = view.findViewById<ConstraintLayout>(R.id.cntFarm)
        val ctnSupplie = view.findViewById<ConstraintLayout>(R.id.cntSupplie)
        val ctnFertilization = view.findViewById<ConstraintLayout>(R.id.cntFertilization)

        ctnRevision.setOnClickListener {
            changeFragment(RevisionFragment.newInstance())
        }
        ctnFarm.setOnClickListener {
            changeFragment(FarmFragment.newInstance())
        }
        ctnSupplie.setOnClickListener {
            changeFragment(SupplieFragment.newInstance())
        }
        ctnFertilization.setOnClickListener {
            changeFragment(TreatmentFragment.newInstance())
        }
        return view
    }

    companion object {
        /**
         * Use this factory method to create a new instance of
         * this fragment using the provided parameters.
         *
         * @param param1 Parameter 1.
         * @param param2 Parameter 2.
         * @return A new instance of fragment HomeFragment.
         */
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance() =
            HomeFragment().apply {
                arguments = Bundle().apply {
                }
            }
    }

    private fun changeFragment(fragment: Fragment) {
        val transaction = parentFragmentManager.beginTransaction()
        transaction.replace(R.id.fragment_container, fragment)
        transaction.addToBackStack(null)
        transaction.setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE)
        transaction.commit()
    }
}