package com.sena.fincaudita.Entity
import android.os.Parcel
import android.os.Parcelable

data class Supplie(
    var Id: Int,
    var Name: String,
    var Description: String,
    var Code: String,
    var Price: Double,
): Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readString() ?: "",
        parcel.readString() ?: "",
        parcel.readDouble()
    ) {
    }

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(Id)
        parcel.writeString(Name)
        parcel.writeString(Description)
        parcel.writeString(Code)
        parcel.writeDouble(Price)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Supplie> {
        override fun createFromParcel(parcel: Parcel): Supplie {
            return Supplie(parcel)
        }

        override fun newArray(size: Int): Array<Supplie?> {
            return arrayOfNulls(size)
        }
    }
}
