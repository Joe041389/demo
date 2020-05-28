class AjaxPostClass{
    constructor(url,post_data,callback_fun){
        this._url = url;
        this._post_data = post_data;
        this._callback_fun = callback_fun;
    }


    
    // 處理一般資料Post
    do_ajax_post(){
        let callback_fun = this._callback_fun;
        ajax_mask();
        //console.log(this._post_data);
        $.ajax({
            url: this._url,
            type: 'post',
            async: true,
            data: this._post_data,
            success: function (ret) {

                callback_fun(ret);
                $.unblockUI();
            },
            error: function (xhr) {
                console.log('Ajax error:' + xhr);
            }
          });
    }

    // 處理一般資料Get
    do_ajax_get(){
        let callback_fun = this._callback_fun;
        ajax_mask();
        //console.log(this._post_data);
        $.ajax({
            url: this._url,
            type: 'get',
            async: true,
            data: this._post_data,
            success: function (ret) {

                callback_fun(ret);
                $.unblockUI();
            },
            error: function (xhr) {
                console.log('Ajax error:' + xhr);
            }
        });
    }

    // 處理一般資料Put
    do_ajax_put() {
        let callback_fun = this._callback_fun;
        ajax_mask();
        //console.log(this._post_data);
        $.ajax({
            url: this._url,
            type: 'put',
            async: true,
            data: this._post_data,
            success: function (ret) {

                callback_fun(ret);
                $.unblockUI();
            },
            error: function (xhr) {
                console.log('Ajax error:' + xhr);
            }
        });
    }

    // 處理一般資料DELETE
    do_ajax_delete() {
        let callback_fun = this._callback_fun;
        ajax_mask();
        //console.log(this._post_data);
        $.ajax({
            url: this._url,
            type: 'delete',
            async: true,
            data: this._post_data,
            success: function (ret) {

                callback_fun(ret);
                $.unblockUI();
            },
            error: function (xhr) {
                console.log('Ajax error:' + xhr);
            }
        });
    }


    // 處理一般匯入資料Post
    do_ajax_import_post(){
      let callback_fun = this._callback_fun;
      ajax_mask();
      $.ajax({
          url: this._url,
          type: 'POST',
          async: true,
          data: this._post_data,
          processData: false,
          contentType: false,
          success: function (ret) {
              callback_fun(ret);
              $.unblockUI();
          },
          error: function (xhr) {
              console.log('Ajax error:' + xhr);
          }
        });
   } 

    // 處理檔案上傳
    do_ajax_upload_post(){
        let callback_fun = this._callback_fun;
        ajax_process_mask();
        $.ajax({
            xhr :function(){
                var xhr = new window.XMLHttpRequest();
                xhr.upload.addEventListener('progress',function(e){
                    if (e.lengthComputable){
                        console.log('Bytes loaded:' + e.loaded);
                        console.log('Total Size:' + e.total);
                        console.log('Percentage Uploaded:' + (e.loaded / e.total));
                        
                        var precent = Math.round((e.loaded / e.total) * 100);
                        $('#progressBar').attr('aria-valuenow',precent).css('width', precent +'%').text(precent + '%');

                    }
                });
                return xhr;
            },
            url: this._url,
            type: 'POST',
            cache: false,
            data: this._post_data,
            processData: false,
            contentType: false,
            success: function(ret) {

                callback_fun(ret);
                $.unblockUI();
            }
        });
    }

}

// ===================ajax mask======================
function ajax_mask(){
  
    $.blockUI({ 
      css: { 
        border: 'none', 
        padding: '15px', 
        backgroundColor: '#0000', 
        '-webkit-border-radius': '10px', 
        '-moz-border-radius': '10px', 
        opacity: .5, 
        color: '#ffff' 
      },
      message: `<img src="../images/loading.gif"/>`,
      baseZ: 99999
    });
  }
  
  
  // ===================ajax process mask======================
  function ajax_process_mask(){
    
    $.blockUI({ 
      css: { 
        border: 'none', 
        padding: '15px', 
        backgroundColor: '#0000', 
        '-webkit-border-radius': '10px', 
        '-moz-border-radius': '10px', 
        opacity: .5, 
        color: '#ffff' 
      },
      message: ' <div class="progress" style="height: 20px;width: 100%">' +
      '<div id="progressBar" class="progress-bar progress-bar-striped" role="progressbar" style="width: 0%" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">0%</div>' +
      '</div>',
      baseZ: 99999
    });
  }