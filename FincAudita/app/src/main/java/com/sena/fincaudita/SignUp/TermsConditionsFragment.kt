package com.sena.fincaudita.SignUp

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.sena.fincaudita.R

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER

/**
 * A simple [Fragment] subclass.
 * Use the [TermsConditionsFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class TermsConditionsFragment : Fragment() {
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
        return inflater.inflate(R.layout.fragment_terms_conditions, container, false)
    }

    companion object {
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance() =
            TermsConditionsFragment().apply {
                arguments = Bundle().apply {
                }
            }
    }
}