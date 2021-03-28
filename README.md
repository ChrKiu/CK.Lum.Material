# CK.Lum.Material

Connection values to the DB have to be set in appsettings.json

Api Calls:

##Get all Material
```
GET /material/
Returns Http 200 on Success with a list of all materials
```

##Get one Material by ID
```
GET /material/{id}
Returns Http 200 on Success with a material
```

##Create a Material
Material Data must be added in the POST-Body as Json in the form of:
```
{
    "id": "<id>",
    "name": "<name>",
    "isVisible": <true/false>,
    "typeOfPhase": "<solid/liquid>",
    "materialFunction": {
        "minTemperature": <number>,
        "maxTemperature": <number>
    }
}
```

Empty values will be ignored by the server
```
POST /material/
Returns Http 200 on Success with the created Material
Returns Http 422 on Failure when the server validates the input as invalid
```

##Update a Material
Material Data must be added in the PUT-Body as Json in the form of:
```
{
    "id": "<id>",
    "name": "<name>",
    "isVisible": <true/false>,
    "typeOfPhase": "<solid/liquid>",
    "materialFunction": {
        "minTemperature": <number>,
        "maxTemperature": <number>
    }
}
```
Every value which has no value is considered to be a change for removing the content. To just change one value, all other values have to be entered too
```
PUT /material/{id}
Returns Http 200 on Success with the updated Material
Returns Http 422 on Failure when the server validates the input as invalid
```

##Delete a Material
```
DELETE /material/{id}
Returns Http 200 on Success
```