Программа, которая сможет ответить на вопрос "Сколько придёт мне на Steam, если я пополню счёт через ~~Qiwi или~~ WebMoney?"

## Системные требования
Основная версия программы (SteamCurrency.exe) требует Windows 10 (версию 1607) и новее и [.Net 8](https://dotnet.microsoft.com/en-us/download) (любой вариант)

Автономная версия программы (SteamCurrency.7z) не требует .Net 8.

## Работа программы
Программа через Rest-запросы узнаёт у Steam (окольными путями), WebMoney ~~и Qiwi (через API)~~ курсы валют и производит вычисления суммы, которая поступит, и суммы, которую "съест" конвертация.
### [Скачать программу](https://github.com/OneCodeUnit/SteamCurrency/releases/latest)
### [Как пополнять Steam](https://github.com/OneCodeUnit/SteamCurrency/wiki/Оглавление)

## Обратите внимание
+ Курсы у Steam, ~~Qiwi~~ и WebMoney отличаются от биржевых, поэтому их необходимо узнавать.
+ Программа сохраняет курсы с предыдущего запуска и может производить расчёты по ним без подключения к интернету.
+ Курс стима считается через сравнение цен на торговой площадке у одного и того же товара. Возможно, есть более правильный способ, так как цены на торговой площадке округлены до двух знаков после запятой, что приводит к погрешности при вычислениях в пределах 1 рубля.
+ ~~Qiwi конвертирует валюты по курсам, которые выше тех, о котором он сообщает. Я не знаю, почему так, но примерно их высчитал и внёс в программу.~~
+ Курс WebMoney берется на основе справночного с сайта сервиса. Курс для вашей сделки стоит вписать самостоятельно - он обычно заметно ниже справочного.
+ WebMoney имеет комиссию 18% (на практике 16%) на пополнение Steam. Программа это учитывает.
+ Существует вероятность, что программа может не получить или получить неправильные курсы. Подождите некоторое время и попробуйте снова.
+ Не стоит проверять курсы слишком часто (речь о десятках раз в час), так как это может привести к временному бану по IP.

## Приглашение на сервер автора программы [Vanilla Russian Expanded](https://discord.gg/GB2e2VhgVE), посвященный RimWorld, модам и переводам.
