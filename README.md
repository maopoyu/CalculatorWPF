# CalculatorWPF

これは、WPF (.NET 8) を使用して作成されたシンプルな電卓アプリケーションです。

### 主な機能

-   基本的な四則演算 (+, -, ×, ÷)
-   メモリ機能 (M+, M-, MRC)
-   `=` キーによる計算の継続実行
-   キーボード入力のサポート
-   最大20桁の表示制限
-   `decimal` 型を使用した高精度な計算

### 動作環境

-   [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
-   [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) または互換性のあるIDE

### ビルドと実行方法

1.  **リポジトリをクローン:**
    ```sh
    git clone https://github.com/maopoyu/CalculatorWPF.git
    cd CalculatorWPF
    ```

2.  **Visual Studioでソリューションを開く:**
    -   `CalculatorWPF.sln` ファイルを Visual Studio 2022 で開きます。

3.  **ソリューションをビルド:**
    -   メニューバーから `ビルド` > `ソリューションのビルド` を選択します (または `Ctrl+Shift+B`)。

4.  **アプリケーションを実行:**
    -   メニューバーから `デバッグ` > `デバッグの開始` を選択します (または `F5`)。

または、コマンドラインからビルドと実行を行うこともできます:

```sh
# プロジェクトディレクトリに移動
cd CalculatorWPF

# プロジェクトをビルド
dotnet build

# アプリケーションを実行
dotnet run
```

### プロジェクト構成

このプロジェクトは MVVM (Model-View-ViewModel) デザインパターンを採用しています。

-   `/Models`: アプリケーションの中核となるビジネスロジック (例: `CalculatorModel.cs`)
-   `/ViewModels`: プレゼンテーションロジックと状態管理 (例: `CalculatorViewModel.cs`, `RelayCommand.cs`)
-   `/Views`: UIの定義 (XAML) とコードビハインド (例: `CalculatorView.xaml`)

### 対応キーボードショートカット

-   **数字キー (0-9, .)**: 数字と小数点の入力
-   **演算子キー (+, -, *, /)**: 四則演算の選択
-   **Enter**: 計算の実行 (=)
-   **Escape**: 全クリア (AC)
-   **Delete**: 入力中数値のクリア (C)
-   **Backspace**: 最後の一文字を削除

---

A simple calculator application built with WPF and .NET 8.

## Features

- Basic arithmetic operations (+, -, ×, ÷)
- Memory functions (M+, M-, MRC)
- Calculation history continuation with the equals key
- Keyboard input support
- Display limited to 20 characters
- High-precision calculations using `decimal` type

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or another compatible IDE

## How to Build and Run

1.  **Clone the repository:**
    ```sh
    git clone https://github.com/maopoyu/CalculatorWPF.git
    cd CalculatorWPF
    ```

2.  **Open the solution in Visual Studio:**
    - Open the `CalculatorWPF.sln` file in Visual Studio 2022.

3.  **Build the solution:**
    - From the menu bar, select `Build` > `Build Solution` (or press `Ctrl+Shift+B`).

4.  **Run the application:**
    - From the menu bar, select `Debug` > `Start Debugging` (or press `F5`).

Alternatively, you can build and run the application from the command line:

```sh
# Navigate to the project directory
cd CalculatorWPF

# Build the project
dotnet build

# Run the application
dotnet run
```

## Project Structure

This project follows the Model-View-ViewModel (MVVM) design pattern.

- `/Models`: Contains the core business logic (e.g., `CalculatorModel.cs`).
- `/ViewModels`: Contains the presentation logic and state management (e.g., `CalculatorViewModel.cs`, `RelayCommand.cs`).
- `/Views`: Contains the UI definitions (XAML) and code-behind (e.g., `CalculatorView.xaml`).

## Implemented Keyboard Shortcuts

- **Numeric Keys (0-9, .)**: Input numbers and decimal point.
- **Operator Keys (+, -, *, /)**: Select arithmetic operations.
- **Enter**: Calculate the result (=).
- **Escape**: Clear all inputs (AC).
- **Delete**: Clear the current entry (C).
- **Backspace**: Delete the last character. 