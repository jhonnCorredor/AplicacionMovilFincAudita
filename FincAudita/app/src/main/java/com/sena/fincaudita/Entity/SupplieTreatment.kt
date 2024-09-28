package com.sena.fincaudita.Entity

import android.os.Parcel
import android.os.Parcelable

data class SupplieTreatment(
    var id: Int,
    var dose: String,
    var suppliesId: Int,
    var supplie: String
) : Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readInt(),
        parcel.readString() ?: ""
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(id)
        parcel.writeString(dose)
        parcel.writeInt(suppliesId)
        parcel.writeString(supplie)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<SupplieTreatment> {
        override fun createFromParcel(parcel: Parcel): SupplieTreatment {
            return SupplieTreatment(parcel)
        }

        override fun newArray(size: Int): Array<SupplieTreatment?> {
            return arrayOfNulls(size)
        }
    }
}
