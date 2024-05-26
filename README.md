# Projet pour tester .Net 8 et WebAPI

Projet pour tester et voir les différences entre .Net 6.0 et .Net 8.0 ainsi que .Net MVC.

## Lancer le projet

Vous pouvez le lancer à partir de :

- Visual studio : lancez le projet clients-api (http)
- Ligne de commande : placez-vous dans le répertoire clients-api et tapez ```dotnet run```
- Docker : allez dans le répertoire ```docker-compose-etudiant``` et tapez ```docker-compose up -d```

```console
 pfleon@pflmb  ~/tmp/clients-api  cd docker-compose-etudiant
 pfleon@pflmb  ~/tmp/clients-api/docker-compose-etudiant  docker-compose up -d      
[+] Running 2/3
 ⠸ Network docker-compose-etudiant_default  Created                                      0.4s 
 ✔ Container sqlserver                      Started                                      0.2s 
 ✔ Container api                            Started                                      0.3s
 pfleon@pflmb  ~/tmp/clients-api/docker-compose-etudiant  open http://localhost:2323/swagger
```

## API

Lien pour documentation : https://app.swaggerhub.com/apis/PIERREFRANCOISLEON/clients-api-.Net8/1.0

Version simplifiée dans la suite.

### /api/clients/{clientId}/Adresses

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| Page | query |  | No | integer |
| PageSize | query |  | No | integer |
| clientId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | OK |

#### POST
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| clientId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 201 | Created |
| 400 | Bad Request |

### /api/clients/{clientId}/Adresses/{adresseId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| clientId | path |  | Yes | string (uuid) |
| adresseId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | OK |
| 404 | Not Found |

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| clientId | path |  | Yes | string (uuid) |
| adresseId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 | No Content |
| 400 | Bad Request |
| 404 | Not Found |

#### DELETE
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| clientId | path |  | Yes | string (uuid) |
| adresseId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 | No Content |
| 404 | Not Found |

### /api/Clients

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| Page | query |  | No | integer |
| PageSize | query |  | No | integer |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | OK |

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 201 | Created |
| 400 | Bad Request |

### /api/Clients/{clientId}

#### GET
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| clientId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 200 | OK |
| 404 | Not Found |

#### PUT
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| clientId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 | No Content |
| 400 | Bad Request |
| 404 | Not Found |

#### DELETE
##### Parameters

| Name | Located in | Description | Required | Schema |
| ---- | ---------- | ----------- | -------- | ---- |
| clientId | path |  | Yes | string (uuid) |

##### Responses

| Code | Description |
| ---- | ----------- |
| 204 | No Content |
| 404 | Not Found |

### /api/GenData

#### POST
##### Responses

| Code | Description |
| ---- | ----------- |
| 201 | Created |

## Autres URI

- Swagger : http://<hostname>:<port>/swagger/v1/swagger.json
- Swagger UI : http://<hostname>:<port>/swagger/index.html
- Santé : http://<hostname>:<port>/healthz/live

## Fonctionnalités futures ?

- Multi-tenants
- Authentification

## TODO

- Rendre le code propre
- Implanter les transactions si démo EF en BDA
- Séparer le dépot

## Auteurs

- Pierre-François Léon
