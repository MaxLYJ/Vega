   M S B A M L   `   `   `  ����E  AVegaEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:VegaEditor.EditorsVegaEditor.Editors  5      ;"clr-namespace:VegaEditor.UtilitiesVegaEditor.Utilities  5      M+clr-namespace:VegaEditor.Utilities.ControlsVegaEditor.Utilities.Controls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      ?$clr-namespace:VegaEditor.GameProjectVegaEditor.GameProject  5
      (    "VegaEditor.Editors.WorldEditorView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:VegaEditor.Editors     5      2utl"clr-namespace:VegaEditor.Utilities     5      <ctrl+clr-namespace:VegaEditor.Utilities.Controls     5      6sys&clr-namespace:System;assembly=mscorlib     5	      5proj$clr-namespace:VegaEditor.GameProject     5
      $
|�True��5        � 	Resources  5         True 	 False��%M   &	        &	      ��5   
   True��6)   ��5   
   	False��6+   5       J� InputBindings 5      �� 5   
   
 �� Key$ Z��65    �� 	Modifiers$
 Ctrlf�6=    �� Command 6   �� *UndoCommand+6=   �� 5   
   $ Z��65   $ 
Ctrl+Shiftf�6=    6   �� *RedoCommand+6=   �� 5   
   $ S��65   $
 Ctrlf�6=    6   �� *SaveCommand+6=   �� 5   
   $ F5��6;    6   �� *DebugStartCommand+6;   �� 5   
   $ F5��6K   $
 Ctrlf�6T    6   �� *#!DebugStartWithoutDebuggingCommand+6T   �� 5   
   $ F5��6:   $ Shiftf�6C    6   �� *DebugStopCommand+6C   �� 5   
    �� CommandParameter# [  66   $ F7��6`    6   �� *BuildCommand+6`   .��5      �  � RowDefinitions 5   
   �� 5      $��32 �6   �� 5      .+�5    
   ��  �� Orientation$ 
Horizontal=�6   .+�5!      �� $
��Undo��6   $	��5,0q�6D   ��6$   �� *UndoCommand+6D   �� 5"      $
��Redo��6   $	��5,0q�6D   ��6$   �� *RedoCommand+6D   �� 5#      -   5        $��
New Script��5#      $	��5,0q�6M   {�5$      ��  �� Path$ 	IsEnabled�	 �� ElementName$	 buildButton���� 5%      -   5        
 ��Name$
 buildButton��5%      $��Build��6*   $	��5,0q�6:   #��[  5&   6   ��6   �� *BuildCommand+66   �� 5'      -   5         ��Name$ 	runConfig��5'      $��Center=�6*   $��72��5(       �� SelectedIndex 6"   �� *BuildConfig+.@�5)      �� $��Debug��6   �� 5*      $��Release��6   5+      �� 5,      -   5        $��Primitive Mesh��5,      $
��10,0q�6Y   5-      � 5.   
   $��1��6    � ColumnDefinitions 5/      �� 50      �� 51      $
��Auto �6#   .+�53      � $��0��6    54      �� 55      �� 56      .+�58      �  59      �� 5:      �� 5;       5=      �� 5>      �� 5?      .+�5A      �� $��0��6#   $��2��60   $��0��6A   
������ $��Stretch=�5B   #   $��Right=�6?   $��5��6[   �� 5C      $��1��6#   $��2��60   $��0��6D   
������ $	��Top=�5D   #   $��Stretch=�6;   $��5��6Y   ,   &VegaEditor.Utilities.RenderSurfaceView  5E      $��0��6,   $��0��69   $��0,0,5,0q�6I     5F      $��0��6,   $��1��69   $��0,0,0,0q�6I     5G      $��1��6,   $��0��69   $��0,5,5,0q�6I     5H      $��1��6,   $��1��69   $��0,5,0,0q�6I   5I      �� 5X      $��1��6   $��5��6,   $��Stretch=�67   $	��Top=�5Y      
������ 67   � 5Z      $��1��6   $��0,5,0,0q�6$    5[      �� 5\      �� 5]      .+�5_      '   !VegaEditor.Utilities.UndoRedoView  $��0��6H     Editor.Window.GrayBrush2#��[ 5`   (    � DataContext 5_   '   �� *
UndoRedo+5`   (   �� 5a      $��1��6#   $��5��63   $��Stretch=�6=   $
��Left=�5b   #   
������ 6>   %   VegaEditor.Utilities.LoggerView  5c      $��1��6%   $��5,0,0,0q�65   5d      5e      �� 5f      $��1��6   $��5��6+   $
��Left=�65   $��Stretch=�5g      
������ 67   � 5h      $��1��6   $��5,0,0,0q�6#   $	��250��64    5i      �� 5j      �� 5k      .+�5m      �� $��1��6   $��5��6,   $��Stretch=�67   $	��Top=�5n      
������ 67   *   $VegaEditor.Editors.ProjectLayoutView  5o        Editor.Window.GrayBrush3#��[ 6*   '   !VegaEditor.Editors.GameEntityView  5p      $��1��6'   #��[ 64   $��0,5,0,0q�5q   '   5r      5s      5t      5u      