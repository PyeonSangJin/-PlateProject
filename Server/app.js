const createError = require('http-errors');
const cookieParser = require('cookie-parser');
const express     = require('express');
const app         = express();
const logger      = require('morgan');
const path        = require('path');

const port = process.env.PORT || 3002;

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

let server = app.listen(port);
server.timeout = 5000;
let io = require('./app/routes')(app);
app.set('socketio',io); 

// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(404));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});

console.log("SERVER ON");
exports = module.exports = app;