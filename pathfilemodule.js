var file = require('fs')
file.readFile('file.txt','utf8',(err,data)=>{
    console.log(err,data);
})