package com.sena.fincaudita.Entity

import android.os.Parcel
import android.os.Parcelable

data class Checklist(
    var id: Int,
    var code: String,
    var calification: Int,
    var qualifications: List<Qualification>
) : Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readInt(),
        parcel.createTypedArrayList(Qualification) ?: listOf()
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(id)
        parcel.writeString(code)
        parcel.writeInt(calification)
        parcel.writeTypedList(qualifications)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Checklist> {
        override fun createFromParcel(parcel: Parcel): Checklist {
            return Checklist(parcel)
        }

        override fun newArray(size: Int): Array<Checklist?> {
            return arrayOfNulls(size)
        }
    }
}

