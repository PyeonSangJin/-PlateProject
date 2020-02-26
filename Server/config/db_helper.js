const mariadb = require('mariadb');
 
module.exports = function () {
  let config = require('./db_config'); 
  let pool = mariadb.createPool({
    host: config.host,
    user: config.user,
    port: config.port,
    password: config.password,
    database: config.database,
    multipleStatements: true
  });
 
  return {
    getConnection: function (callback) { // connection pool 리턴
      pool.getConnection()
      .then(conn => {
        callback(conn);
      })
      .catch(err=>{
        console.log(err);
      });
    },
    end: async function(callback){
      pool.end(callback);
    }
  }
}();
