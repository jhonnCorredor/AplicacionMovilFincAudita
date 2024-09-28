package com.sena.fincaudita.Entity

import android.os.Parcel
import android.os.Parcelable

data class Qualification(
    var id: Int,
    var observation: String,
    var qualificationCriteria: Int,
    var assessmentCriteriaId: Int
) : Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readInt(),
        parcel.readInt()
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(id)
        parcel.writeString(observation)
        parcel.writeInt(qualificationCriteria)
        parcel.writeInt(assessmentCriteriaId)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Qualification> {
        override fun createFromParcel(parcel: Parcel): Qualification {
            return Qualification(parcel)
        }

        override fun newArray(size: Int): Array<Qualification?> {
            return arrayOfNulls(size)
        }
    }
}
