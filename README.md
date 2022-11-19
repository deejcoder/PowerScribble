### Creating new migrations

```bash
dotnet ef migrations add "Initial" --startup-project PowerScribble.Api --project PowerScribble.Api.Persistance --context PowerScribble.Api.Persistance.Data.PowerScribbleDbContext
dotnet ef database update --startup-project PowerScribble.Api --project PowerScribble.Api.Persistance --context PowerScribble.Api.Persistance.Data.PowerScribbleDbContext
```