$("#Status").change(function () {
    var str = "";
    $("#Status option:selected").each(function () {
        str += $(this).text();
        if (str === "Reserved") {
            $("#BoughtOut").addClass("hidden");
            $("#Cost").addClass("hidden");
            $("#Reserved").removeClass("hidden");
        } else if (str === "BoughtOut") {
            $("#BoughtOut").removeClass("hidden");
            $("#Cost").removeClass("hidden");
            $("#Reserved").addClass("hidden");
        }
    });
});