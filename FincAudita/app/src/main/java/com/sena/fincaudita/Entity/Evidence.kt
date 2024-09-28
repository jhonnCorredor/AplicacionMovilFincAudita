package com.sena.fincaudita.Entity

import android.os.Parcel
import android.os.Parcelable

data class Evidence(
    var id: Int,
    var code: String,
    var document: String
) : Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString() ?: "",
        parcel.readString() ?: ""
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(id)
        parcel.writeString(code)
        parcel.writeString(document)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Evidence> {
        override fun createFromParcel(parcel: Parcel): Evidence {
            return Evidence(parcel)
        }

        override fun newArray(size: Int): Array<Evidence?> {
            return arrayOfNulls(size)
        }
    }
}
