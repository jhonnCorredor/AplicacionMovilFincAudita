package com.sena.fincaudita.Entity

import android.os.Parcel
import android.os.Parcelable

data class Review(
    var id: Int,
    var date: String,
    var code: String,
    var observation: String,
    var lotId: Int,
    var tecnicoId: Int,
    var lot: String,
    var tecnico: String,
    var checklistId: Int,
    var evidenceList: List<Evidence>,
    var checklist: Checklist?
) : Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readString() ?: "",
        parcel.readString() ?: "",
        parcel.readInt(),
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readString() ?: "",
        parcel.readInt(),
        parcel.createTypedArrayList(Evidence) ?: listOf(),
        parcel.readParcelable(Checklist::class.java.classLoader)
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(id)
        parcel.writeString(date)
        parcel.writeString(code)
        parcel.writeString(observation)
        parcel.writeInt(lotId)
        parcel.writeInt(tecnicoId)
        parcel.writeString(lot)
        parcel.writeString(tecnico)
        parcel.writeInt(checklistId)
        parcel.writeTypedList(evidenceList)
        parcel.writeParcelable(checklist, flags)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Review> {
        override fun createFromParcel(parcel: Parcel): Review {
            return Review(parcel)
        }

        override fun newArray(size: Int): Array<Review?> {
            return arrayOfNulls(size)
        }
    }
}

