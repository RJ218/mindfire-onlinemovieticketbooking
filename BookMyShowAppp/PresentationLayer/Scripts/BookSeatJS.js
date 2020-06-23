$.ajax(
          {
        type: "GET", url: "http://localhost:60562//api/Default",
        headers: {
            'Authorization': 'Bearer ' + sessionStorage.getItem("token") + ":" + sessionStorage.getItem("username")
        },

              success: (response) => {
                  for (var i = 0; i < response.length; i++) {
                      var br = response[i];
                      var str = br.TheatreName;
                      var str1 = br.DateTime;
                      $(".emptable").append(str);
                      $(".emptable").append("<br/>");
                      $(".emptable").append(str1);
                      $(".emptable").append("<br/>");

                  }
              }

              , error: (err) => {
                  alert(err);
                  console.log(err);
              }
          });