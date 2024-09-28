package com.sena.fincaudita.Config

class urls {
    companion object{
        val urlBasic="http://10.192.88.28:9191/"
        val urlLogin= urlBasic+"login"
        val urlPerson= urlBasic+"api/Person"
        val urlUser= urlBasic+"api/User"
        val urlCity= urlBasic+"api/City"
        val urlAlert= urlBasic+"api/Alert"
        val urlNotification= urlAlert+"/Notifications"
        val urlFarm= urlBasic+"api/Farm"
        val urlSupplies= urlBasic+"api/Supplies"
        val urlCrop= urlBasic+"api/Crop"
        val urlTreatment= urlBasic+"api/Treatment"
        val urlReview = urlBasic+"api/ReviewTechnical"
        val urlAssesment= urlBasic+"api/AssesmentCriteria"
    }
}