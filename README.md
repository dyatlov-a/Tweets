# Tweets

Отображение твитов по тегу

## Развертывание back-end части
- открыть проект в Visual Studio 2017
- простроить проект (восстановить NuGet-пакеты)
- сконфигурировать строку подключения DefaultConnection
- при помощи Package-Manager Console выполнить команду `update-database`
- запустить проет (при необходимости развернуть на локальном IIS)

## Описание настроек
1. Строка подключения **DefaultConnection**
2. Секция TwitterClientSettings
- CultureInfo
- DateTimeFormat
- TokenUrl
- QueryUrlPattern
- ConsumerKey
- ConsumerSecret
- TweetsFieldName
- AccessTokenFieldName
3. Секция TweetsSettings
- TweetsCount
- IsSaveHistory
- ResultType

## Swagger
![Swagger](/docs/swagger.png)

## Развертывание front-end части
- установить nodejs (включая npm)
- перейти в директорию **Tweets.Front**
- в файле **package.json** в разделе **scripts** указать url до back-end части
- запустить CMD и выполнить команды: `npm install`, `npm run dev`

![app](/docs/app.png)