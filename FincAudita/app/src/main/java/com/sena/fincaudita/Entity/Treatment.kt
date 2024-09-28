package com.sena.fincaudita.Entity

import android.os.Parcel
import android.os.Parcelable

data class Treatment(
    var id: Int,
    var dateTreatment: String,
    var typeTreatment: String,
    var quantityMix: String,
    var lotList: List<LotTreatment>,
    var supplieList: List<SupplieTreatment>
) : Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readString() ?: "",
        parcel.readString() ?: "",
        parcel.createTypedArrayList(LotTreatment) ?: listOf(),
        parcel.createTypedArrayList(SupplieTreatment) ?: listOf()
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(id)
        parcel.writeString(dateTreatment)
        parcel.writeString(typeTreatment)
        parcel.writeString(quantityMix)
        parcel.writeTypedList(lotList)
        parcel.writeTypedList(supplieList)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Treatment> {
        override fun createFromParcel(parcel: Parcel): Treatment {
            return Treatment(parcel)
        }

        override fun newArray(size: Int): Array<Treatment?> {
            return arrayOfNulls(size)
        }
    }
}
