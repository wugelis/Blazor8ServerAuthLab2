# Blazor 由淺入深系列課程 - 課程範例

這裡是「Blazor 由淺入深系列課程」的課程範例專案，透過這個專案，你可以學到如何使用 Blazor 開發 Web 應用程式，並學習到如何建置具備 Authentication 的 Blazor 系統。

## Lab 實作範例程式

* 因此在網頁常見 Stateless 架構，但為了識別操作者身分，除了 Kerberos 或 Form 驗證，其實也有土法煉鋼法，但重點在於在分散式環境中，也能（保存/識別）〔身分/狀態〕

## 身分驗證 Login 功能實作
(1). 可使用我的自定義套件功能  
(2). 使用客製化的 NewCookie 取代內建的 HttpCookie  
(3). 如何純手工實作 Token？  
(4). Blazor 的狀態 Status 保存實戰  

這個範例包含一個 AuthenticationStateProvider 抽象類別的擴充套件，用以簡化原有在實作 Blazor 的驗證功能的複雜度。

## 本軟體授權方式

本軟體使用 MIT 授權條款（Massachusetts Institute of Technology）, Copyright (C) 2024 Gelis Wu.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.