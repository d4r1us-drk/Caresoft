Estructura del CORE

```
caresoft_core/
├── cmd/
│   └── server/
│       └── main.go         # Punto de entrada de la aplicación
│
├── internal/
│   ├── handlers/           # Controladores HTTP
│   │   └── user_handler.go
│   │   └── product_handler.go
│   │   └── ...
│   │
│   ├── models/             # Definiciones de modelos
│   │   └── user.go
│   │   └── product.go
│   │   └── ...
│   │
│   └── db/                 # Funciones para interactuar con la base de datos
│       └── database.go
├── config/
│   └── config.yaml         # Configuración de la aplicación
├── go.mod
└── go.sum
```
