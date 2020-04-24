# UdonSharpShooting_v2
UdonSharp(U#)を使ったVRChat上で動作する的当てゲームのプロジェクト  
プロジェクトに含まれるアセットはすべてCC0です（自作）

## 動作環境
Unity2018.4.20.f1  
VRChat SDK VRCSDK3-UDON-2020.04.09.16.59_Public以降  
Udon Sharp UdonSharp_v0.15.1以降  

## セットアップ（適当）
AudioSettingsにBGM、SEを追加  
GunSettingsで弾数を設定  
TimeManagerで制限時間を設定  
Targetに出現時間帯、得点、耐久力、復活間隔を設定  
銃の数を増やす場合は銃を複製する（Gunsの子から出さないようにする）    
ScoreTextとScoreDataとNameTextとNameDataを必要な数複製し、対応するplayerIDを設定する  playerIDはGunsの子のインデックス

## 配布
https://github.com/tiwa0510/UdonSharpShooting_v2/releases
