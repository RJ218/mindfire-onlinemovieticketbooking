var str1 = "";
var str = "";
var movieid = localStorage.getItem("movieval");
console.log(movieid);
    $.ajax(
           {
               type: "GET", url: "http://localhost:60562//api/GetData?movieid=" + movieid,

               success: (response) => {
                   console.log(response);
                   for (var i = 0; i < response.length; i++) {
                       var br = response[i];
                      //console.log(br.TheatreId);
                       if (str != br.TheatreName) {
                           str = br.TheatreName;
                           var str2 = br.TheatreId;
                           var str3 = br.ShowId;
                           document.getElementById("emptable").innerHTML += "<br/><br/>" + "<a class='xx'>" + str + "</a>" + "<br/>";
                       }
                       str1 = br.DateTime;
                       document.getElementById("emptable").innerHTML += "<a class='cityLink' id='" + str +"' value='"+str2 +"' name='"+str3 +"'>" + str1 + "</a>" + "&nbsp&nbsp&nbsp";
                   }// console.log(theatreid);
                   $(document).ready(function () {
                       $(".cityLink").click(function () {
                           $(".cityLink").removeClass('active');
                           var time = $(this).addClass('active').text();
                           var theatrename = $(this).attr("id");
                           var theatreId = $(this).attr("value");
                           var showId = $(this).attr("name");
                           console.log(showId);
                           console.log(theatreId);
                           localStorage.setItem("theatreid", theatreId);
                           localStorage.setItem("showid", showId);
                           localStorage.setItem("theatrenm", theatrename);
                           console.log(theatrename);
                           localStorage.setItem("time", time);
                           console.log(localStorage.getItem("time"));

                       });
                   });


               }

               , error: (err) => {
                   alert(err);
                   console.log(err);
               }
           });
//function func()
  //  document.getElementById("pvrname").innerHTML = localStorage.getItem("theatrenm");