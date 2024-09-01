const express = require('express')
const bodyParser = require('body-parser')
const fs = require('fs')

const app = express();
app.use(bodyParser.json());

app.get('/polyglot/test',(req,res) =>{
    console.log("polyglot_nodejs.index.get/test")
    console.log(req.body)
    res.send('get test successful')
})

app.post('/polyglot/test', (req, res)=>{
    console.log("polyglot_nodejs.index.post/test");
    req.body["message3"] = req.body.message + " from Node.js"
    req.body["user"]={
        "firstName":"John",
        "lastName":"Doe"
    }
    res.send(req.body);
    
})

app.listen(5001, ()=>{
    console.log("Polyglot_nodejs is listening on port 5001")
})