package com.sena.fincaudita

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.view.Gravity
import android.view.LayoutInflater
import android.view.View
import android.view.Window
import android.view.WindowManager
import android.widget.Button
import android.widget.ImageButton
import android.widget.PopupWindow
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.content.ContextCompat
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import androidx.fragment.app.Fragment
import com.sena.fincaudita.Farm.FarmFragment
import com.sena.fincaudita.Supplie.SupplieFragment
import com.sena.fincaudita.Treatment.TreatmentFragment
import com.sena.fincaudita.review.RevisionFragment

class MenuActivity : AppCompatActivity() {
    private lateinit var allButtons: List<Button>

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_menu)
        val window: Window = this.window
        window.clearFlags(WindowManager.LayoutParams.FLAG_TRANSLUCENT_STATUS)
        window.addFlags(WindowManager.LayoutParams.FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS)
        window.statusBarColor = ContextCompat.getColor(this, R.color.green)

        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.menu)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val btnUser = findViewById<ImageButton>(R.id.btnUser)
        val btnAlert = findViewById<ImageButton>(R.id.btnAlert)
        val btnHome = findViewById<Button>(R.id.btnHome)
        val btnRevision = findViewById<Button>(R.id.btnRevision)
        val btnFertilization = findViewById<Button>(R.id.btnFertilization)
        val btnSupplie = findViewById<Button>(R.id.btnSupplie)
        val btnFarm = findViewById<Button>(R.id.btnFarm)

        allButtons = listOf(btnHome, btnRevision, btnFertilization, btnSupplie, btnFarm)

        btnUser.setOnClickListener {
            showCustomPopupWindow(it)
        }

        btnHome.setOnClickListener {
            changeFragment(HomeFragment.newInstance())
            colorButton(btnHome)
        }

        btnAlert.setOnClickListener {
            changeFragment(NotificationFragment.newInstance())
        }

        btnRevision.setOnClickListener {
            changeFragment(RevisionFragment.newInstance())
            colorButton(btnRevision)
        }

        btnFertilization.setOnClickListener {
            changeFragment(TreatmentFragment.newInstance())
            colorButton(btnFertilization)
        }

        btnSupplie.setOnClickListener {
            changeFragment(SupplieFragment.newInstance())
            colorButton(btnSupplie)
        }

        btnFarm.setOnClickListener {
            changeFragment(FarmFragment.newInstance())
            colorButton(btnFarm)
        }
    }

    private fun showCustomPopupWindow(view: View) {
        val inflater = LayoutInflater.from(this)
        val popupView = inflater.inflate(R.layout.menu_perfil, null)

        val popupWindow = PopupWindow(
            popupView,
            WindowManager.LayoutParams.WRAP_CONTENT,
            WindowManager.LayoutParams.WRAP_CONTENT
        ).apply {
            isFocusable = true
            setBackgroundDrawable(ContextCompat.getDrawable(this@MenuActivity, android.R.color.transparent))
        }

        popupView.findViewById<TextView>(R.id.action_perfil).setOnClickListener {
            changeFragment(PerfilFragment.newInstance())
            popupWindow.dismiss()
        }

        popupView.findViewById<TextView>(R.id.action_cerrar_sesion).setOnClickListener {
            val sharedPreferences = getSharedPreferences("user_prefs", Context.MODE_PRIVATE)
            val editor = sharedPreferences.edit()
            editor.clear()
            editor.apply()

            val intent = Intent(this@MenuActivity, MainActivity::class.java)
            startActivity(intent)
            finish()
            popupWindow.dismiss()
        }

        popupWindow.showAsDropDown(view, 0, 0, Gravity.START)
    }

    private fun colorButton(button: Button){
        for (btn in allButtons) {
            btn.setBackgroundColor(ContextCompat.getColor(this, android.R.color.white))
        }
        button.setBackgroundColor(ContextCompat.getColor(this, R.color.green))
    }

    private fun changeFragment(fragment:  Fragment?){
        val fragmentManager = supportFragmentManager
        val fragmentTransaction = fragmentManager.beginTransaction()
        fragmentTransaction.replace(R.id.fragment_container, fragment!!)
        fragmentTransaction.commit()
    }
}