package com.sena.fincaudita.components

import android.app.DatePickerDialog
import android.app.Dialog
import android.content.Context
import android.os.Bundle
import android.widget.DatePicker
import androidx.fragment.app.DialogFragment
import java.util.Calendar

class DatePickerFragment (val listener: (day:Int,month:Int,Year:Int )-> Unit): DialogFragment(),
    DatePickerDialog.OnDateSetListener {
    override fun onDateSet(view: DatePicker?, year: Int, month: Int, dayOfMonth: Int) {
        listener(dayOfMonth,month,year)
    }

    override fun onCreateDialog(savedInstanceState: Bundle?): Dialog {
        val calendar: Calendar = Calendar.getInstance()
        val day:Int = calendar.get(Calendar.DAY_OF_MONTH)
        val month:Int = calendar.get(Calendar.MONTH)
        val year:Int = calendar.get(Calendar.YEAR)
        val picker =DatePickerDialog(activity as Context, this,year,month,day)
        return picker
        }
}