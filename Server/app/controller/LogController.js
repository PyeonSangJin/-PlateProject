const pool = require('../../config/db_helper');

module.exports = {
    insertLog: function(req,res){
       // console.log(req.body.ipaddr );
        //console.log(req.body.userId );
        
        try {
            pool.getConnection( (conn) => {
                conn.query('CALL CREATE_ACCESSLOG(\''+ req.body.ipaddr+ '\', \'' + req.body.userId +'\', @_RESMSG);')
                .then((results) => {
                   // console.log(results);
                    res.send(results[1][0])
                    conn.end();
                })
            });
        } 
        catch (error) {
            console.log(error);   
        }
    }
}
