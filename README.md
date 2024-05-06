# dotnet_BlazorHybrid7

## 概要
* 試行錯誤中
* ベース: [dotnet_BlazorHybrid6](https://github.com/Tobotobo/dotnet_BlazorHybrid6)
* App に Maui 追加　※途中
* Todo ページ追加　※途中
* CSS が charset と異なり UTF-8 with BOM で保存されていたことで一部スタイルが適用されなかった問題を修正 
* DevContainer で Android の publish 対応　※途中

![](/doc/image/図1.drawio.png)

※詳細は [構成説明](/doc/構成説明.md) を参照

## ターゲット
* まだデスクトップアプリ開発が必用だが、Web アプリやスマホアプリ開発につなげていきたい
* 開発環境が Windows の Visual Studio に縛られているのを脱却したい

## 想定する使い方
* ローカルに Docker 環境を作るか、外部の Docker がインストールされた環境に Remote-SSH で接続し DevContainer で開発する  
  ※DevContainer を用いずにローカルに直接 .NET 8 をインストールして開発も可能

* View の実装は、デバッグ実行「.NET Core Launch (Web)」やタスク「👀watch-web」を用いてブラウザでプレビューしながら行う  
  ※要ポートフォワーディング

* 一通りできたらタスク「📤publish-forms」や「📤publish-wpf」で実行ファイルを作成する  
  ※スマホアプリは未実装（今後追加したい）

## トラブルシューティング
* VSCode でフォルダ開いた直後から大量のエラーが出る  
  →　以下を試して
    * タスク「🔄restore」を実行
    * タスク「🧹clean」を実行
    * コマンド「開発者:ウィンドウの再読み込み」
* publish の実行後などに、BlazorHybrid.App.Wpf の Program.cs がエラーになる  
  →　なぜか知らんが Program.cs を一度開けばエラーが消える
* [開発コンテナでプロファイルを適用すると「... のファイル システム プロバイダーが見つかりません」と表示されワークスペースが開けない](https://github.com/Tobotobo/dotnet_BlazorHybrid5/issues/1)

## コマンド
* デバッグ実行 `F5`
  * .NET Core Launch (Web)
  * .NET Core Attach
* タスク
  * 👀watch-web `Ctrl + Shift + B`
  * 📤publish-forms
  * 📤publish-wpf
  * 🛠️build-web
  * 🧪test
  * 🧹clean
  * 🔄restore

※ publish ではワークスペース直下に publish フォルダを作成しそこに出力する。

## 環境
```
> dotnet --info   
.NET SDK:
 Version:           8.0.204   
 Commit:            c338c7548c
 Workload version:  8.0.200-manifests.c4df6daf

ランタイム環境:
 OS Name:     Windows
 OS Version:  10.0.19045
 OS Platform: Windows
 RID:         win-x64
 Base Path:   C:\Program Files\dotnet\sdk\8.0.204\
```

## 参考サイト
感謝！
* [ねこじょーかー/Blazor HybridとBlazor Web AppのUIをRCLで共通化する手順](https://blazor-master.com/blazor-hybrid-maui-rcl/)
* [nekojoker/BlazorHybrid](https://github.com/nekojoker/BlazorHybrid)
    > .NET MAUI Blazor アプリと Blazor Web App の Razor コンポーネントや静的資産を Razor クラスライブラリで共通化したプロジェクトです。  
    > .NET 8 に対応しています。
