
//$("#get").click(() => {
    // var movieid = 2;
//var movieid = $("h1").attr("id");
var str1 = "";
var str = "";
    var movieid = localStorage.getItem("movieval");
    $.ajax(
           {
               type: "GET", url: "http://localhost:64810//api/Home?movieid=" + movieid,

               success: (response) => {
                   for (var i = 0; i < response.length; i++) {
                       var br = response[i];
                       if (str != br.TheatreName) {
                           str = br.TheatreName;
                           document.getElementById("emptable").innerHTML += "<br/><br/>"+"<a class='xx'>" + str + "</a>" + "<br/>";
                       }
                       str1 = br.DateTime;
                       document.getElementById("emptable").innerHTML += "<a class='cityLink' id='"+str+"'>" + str1 + "</a>"+"&nbsp&nbsp&nbsp";
                       
                       // $(".emptable").append(str);
                      // $("#emptable").append("<br/>");
                      // $("#emptable").append(str1);
                       //$("#emptable").append("<br/>");
                   }
                  
                 /*  $("a").click(function () {
                       var card = $(this);
                       var storage = $(".seat").text();
                       console.log(storage);
                       card.toggleClass('highlight');
                       localStorage.setItem("local", storage);
                       
                   })*/
                   $(document).ready(function () {
                       $(".cityLink").click(function () {
                           $(".cityLink").removeClass('active');
                           var x = $(this).addClass('active').text();
                           localStorage.setItem("local",x);
                             //  var storage = $(".cityLink").text();
                           console.log(localStorage.getItem("local"));
                           
                       });
                   });
                   
                  
               }

               , error: (err) => {
                   alert(err);
                   console.log(err);
               }
           });
    
//});
