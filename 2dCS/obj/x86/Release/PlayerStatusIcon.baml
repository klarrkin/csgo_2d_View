   M S B A M L   `   `   `  ���� ?  ;2dCS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:_2dCS.Converter_2dCS.Converter      _2dCS.PlayerStatusIcon   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .convclr-namespace:_2dCS.Converter       � 	Resources  ,   &_2dCS.Converter.StringToImageConverter   StringToImageConverter#   _2dCS.Converter.MathConverter  MathConverter+   %_2dCS.Converter.BoolToStringConverter�   �_2dCS.Converter.BoolToValueConverter`1[[System.String, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   
FalseValue   	TrueValue  BoolToStringConverter��%A   &	        &	      &	 
           $	 ✗��$	 ✓��.���� 
�������
�������$��4q�$��60��$��58��$��2q�._��  � ColumnDefinitions �� $��20 ��� $��40 � � RowDefinitions �� $��18 ��� $��20 ��� $��20 �.+��� $��0��$��2��$��0��$��1��$��1q�
�������
���   �._��� 
�������$��10(�$
��Bold"�$��Center=����� *Name+�� $��0��$��2��$��1��$��2��$��60��$��Bottom=����� *Health+ �� 	Converter# [  �� ConverterParameter$ @VALUE*5/10������ *Color+�� $��0��$��1��$��1��$��1��$��1q�
�������._��� 
�������$��10(�$��Center=����� *Bez+�� $��1��$��1��$��1q�
�������._��� 
�������$��10(����� *
WeaponType+�� $��1��$��2��$��1q�
�������._��� 
�������$��10(����� *Money+�� $��0��$��2��$��1��$��1��$��1q�
�������._��� 
�������$��10(���`�  �� StringFormat$ {0}{1}��.1���  �� Path$ HasArmor�# [ �� $ 	HasHelmet�# [ 