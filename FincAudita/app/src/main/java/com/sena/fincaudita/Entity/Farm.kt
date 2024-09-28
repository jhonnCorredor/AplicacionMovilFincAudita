package com.sena.fincaudita.Entity

import android.os.Parcel
import android.os.Parcelable

data class Farm(
    val Id: Int,
    val Name: String,
    val CityId: Int,
    val UserId: Int,
    val Addres: String,
    val Dimension: Int,
    //val Lots: mutableListOf<Lot>,
) : Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readInt(),
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readInt(),
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(Id)
        parcel.writeString(Name)
        parcel.writeInt(CityId)
        parcel.writeInt(UserId)
        parcel.writeString(Addres)
        parcel.writeInt(Dimension)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Farm> {
        override fun createFromParcel(parcel: Parcel): Farm {
            return Farm(parcel)
        }

        override fun newArray(size: Int): Array<Farm?> {
            return arrayOfNulls(size)
        }
    }
}