              $("#CommentRateUp").click(function () {
                                                    $.get("/Haber/YorumBegen/@item.Id");
                                                });
$("#CommentRateDown").click(function () {
    $.get("/Haber/YorumTiksin/@item.Id");
});
