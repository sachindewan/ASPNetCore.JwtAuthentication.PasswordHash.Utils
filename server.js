const express = require("express");
const fs = require("fs");
const app = express();
const axios = require("axios");
const PORT = process.env.PORT || process.env.APP_PORT || 8081;
//app.use(express.json());
app.get('/',async(req,res)=>{
    //res.statusCode = 200;
    //res.setHeader('Content-Type','text/html');
    const index = fs.readFileSync("index.html");
     console.log(res.statusCode);
    res.end(index.toString());
});
app.get('/about',async(req,res)=>{
    res.send("we are fine buddy how about you !!");
});
app.get('/sachin',async(req,res)=>{
   axios.get("https://61ec17477ec58900177cde74.mockapi.io/api/v1/getAllUsers").then((response)=>{
       res.send(response.data);
   }).catch(error=>{
    console.log(error);
   })
});
app.listen(PORT, () => {
    console.log(`Application listening on port ${PORT}`);
 });