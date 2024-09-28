package com.sena.fincaudita.Entity
import android.os.Parcel
import android.os.Parcelable

data class Lot(
    var Id: Int,
    var CropId: Int,
    var numHectareas: Int,
    var Cultivo: String
) : Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readInt(),
        parcel.readInt(),
        parcel.readString() ?: ""
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(Id)
        parcel.writeInt(CropId)
        parcel.writeInt(numHectareas)
        parcel.writeString(Cultivo)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Lot> {
        override fun createFromParcel(parcel: Parcel): Lot {
            return Lot(parcel)
        }

        override fun newArray(size: Int): Array<Lot?> {
            return arrayOfNulls(size)
        }
    }
}