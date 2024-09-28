import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView

class GenericAdapter<T>(
    private var items: MutableList<T>,
    private val layoutResId: Int,
    private val bindView: (View, T) -> Unit
) : RecyclerView.Adapter<GenericAdapter<T>.ViewHolder>() {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(layoutResId, parent, false)
        return ViewHolder(view)
    }

    override fun onBindViewHolder(holder: ViewHolder, position: Int) {
        val item = items[position]
        bindView(holder.itemView, item)
    }

    override fun getItemCount(): Int {
        return items.size
    }

    fun updateData(newItems: MutableList<T>) {
        items = newItems
        notifyDataSetChanged()
    }

    inner class ViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView)
}

