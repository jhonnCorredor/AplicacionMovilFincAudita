package com.sena.fincaudita.Entity

import android.os.Parcel
import android.os.Parcelable

data class LotTreatment(
    var id: Int,
    var lotId: Int,
    var lot: String
) : Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readInt(),
        parcel.readString() ?: ""
    )

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(id)
        parcel.writeInt(lotId)
        parcel.writeString(lot)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<LotTreatment> {
        override fun createFromParcel(parcel: Parcel): LotTreatment {
            return LotTreatment(parcel)
        }

        override fun newArray(size: Int): Array<LotTreatment?> {
            return arrayOfNulls(size)
        }
    }
}
