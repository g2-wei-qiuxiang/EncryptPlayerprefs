# EncryptPlayerprefs
データを暗号化し、Playerprefsに保存するdemoです。保存できる型はint、float、string、クラスです  
### unityバージョン
2020.3.30f1  
### demo内容
・int、float、string、クラスなどのデータをAES暗号アルゴリズムで暗号化し、PlayerPrefsに保存します  
・PlayerPrefsに保存されたデータをAES暗号アルゴリズムで複合化  
### 内容詳細
暗号化の内容はTools->BGTools->PlayerprefsEditorで見れます  
SampleSceneで動作確認できます。「暗号化し、保存」ボタンは暗号化する動作、「複合化」はPlayerPrefsの内容を複合化します  
<img width="501" alt="スクリーンショット 2022-03-24 17 47 47" src="https://user-images.githubusercontent.com/59904787/159878018-1ca1ff7b-aeea-4545-b86c-805b1194b606.png">
