# FutureWork IA – Avalonia + API
## Integrantes
- Vinicus RM553814
- Gustavo RM554242

Simulador do Trabalho do Futuro com interface desktop em **Avalonia UI** e uma **API REST** para cálculo do índice.

## Requisitos

- SDK do .NET 9 instalado (verifique com `dotnet --version`).

## Como rodar o app desktop (macOS / VS Code)

1. Abra a pasta `FuturoDoTrabalho.Avalonia` no VS Code (ou outro editor).
2. No terminal, dentro da pasta do projeto, rode:

```bash
dotnet restore
dotnet run
```

Uma janela desktop será aberta com o simulador.

## Como rodar a API (mock local)

1. No terminal, na pasta raiz do repositório, rode:

```bash
dotnet run --project FuturoDoTrabalho.Api
```

2. A API irá subir (por padrão em `http://localhost:5000` ou porta similar).

### Endpoint disponível

- `POST /api/simulate`

**Request body (JSON):**

```json
{
  "workModel": "Remoto",
  "automation": 5,
  "wellbeing": 7,
  "inclusion": 6,
  "sustainability": 6
}
```

Valores possíveis para `workModel`: `"Remoto"`, `"Híbrido"`, `"Presencial"`.

**Response body (JSON):**

```json
{
  "index": 72.5,
  "classification": "Bom – ...",
  "recommendations": "Sugestões para aproximar seu trabalho do futuro: ..."
}
```

## Publicação em ambiente cloud (exemplo: Render)

Você pode publicar a API em qualquer provedor cloud que suporte .NET (Azure, Render, Railway, etc.). Um fluxo simples usando **Render**:

1. Crie um repositório no GitHub com este projeto.
2. Crie uma conta em [https://render.com](https://render.com).
3. Em **New +** → **Web Service**, conecte seu repositório.
4. Selecione a pasta raiz do repositório e configure:
   - Build command: `dotnet publish FuturoDoTrabalho.Api/FuturoDoTrabalho.Api.csproj -c Release -o out`
   - Start command: `dotnet FuturoDoTrabalho.Api.dll`
   - Root directory: `out`
5. Após o deploy, Render fornecerá uma URL, por exemplo:

```text
https://futurework-api.onrender.com
```

Seu endpoint em produção ficará, por exemplo:

- `POST https://futurework-api.onrender.com/api/simulate`

Lembre-se de documentar na sua entrega:

- URL pública da API;
- Exemplo de request/response (como acima);
- Se houver autenticação, informar usuário/senha, API key, etc.
