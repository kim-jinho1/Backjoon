using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Configuration.Assemblies;

class Program
{
    static void Main()
    {
        /*      
      ⠡⡡⢡⠑⢅⠣⡑⢕⠱⡱⡩⡪⡪⡱⡱⡩⡪⡪⣱⢕⢍⢎⢎⢎⢎⠪⡊⢎⠪⣊⠪⣊⠪⡊⡪⡊⡪⡊⢎⢊⠪⡊⢎⠪⠪⡪⡊⢎⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡫⡝⡭⣫⢯⠯⡯⣏⢯⣫⣫⣝⣝⢽⢽⢝⡽⢭⡫⣫⡫⡳⣹⢹⣹⡹⡭⡫⣝⢵
      ⢂⢊⠢⠡⡡⡑⢌⠢⡑⢌⠪⡪⢪⠪⡪⢪⠪⡪⡪⣷⢑⢕⠕⡕⢕⢕⢱⢑⢕⢢⠣⡢⣃⢇⢪⠨⠢⡊⡢⡑⡑⢌⠢⡑⡑⢌⢌⠢⡑⢌⠢⡣⠱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡡⡃⢎⠢⡃⡇⣏⢮⢗⣯⢯⡺⡪⣇⢗⢮⣞⢮⣗⢯⣳⡫⣗⢽⡪⡮⡳⣕⢽⢜⢮⡪⣇⢗⢵
      ⢂⠢⠡⡑⡐⠨⡐⡑⢌⠢⡑⢜⠸⡘⡜⢌⢎⢪⠪⣟⣎⢆⢇⢣⢣⠱⡡⡣⡑⡅⢇⢪⡞⢌⠢⡑⢅⢕⢐⠕⢌⠢⡑⢌⢌⠢⠢⡑⢌⠢⡑⠜⡌⡪⡘⡌⢎⢜⢌⢎⢜⢌⢎⠜⡔⡑⡌⡪⡘⡌⡪⣪⢏⢮⢯⣗⡯⣳⢵⢝⣞⢮⣗⢽⢕⣗⢽⣪⡳⡝⡮⡺⣜⢮⢳⡣⡳⣕⣝⢵
      ⢐⠨⢂⠢⡈⡂⡢⠨⡂⢕⠨⠢⡑⡑⢌⠢⡑⢕⠱⡽⡵⡕⡅⢇⢪⠪⡢⡑⢕⢘⢬⡟⢌⠢⡑⢌⠢⠢⢡⠡⡡⡑⢌⢂⠢⠡⡑⢌⠢⡑⢌⢊⠢⡑⢌⠪⡘⢔⠱⡨⢢⠣⡊⡎⢜⢌⠆⡕⢌⢪⢸⢸⢝⢎⢧⡳⡯⡯⣫⢗⣗⢯⢮⣫⡳⣕⢗⣕⢧⢫⡺⣪⡺⣪⡣⡏⣞⢎⢮⡺
      ⠐⠨⢐⢐⢐⠐⢌⠐⢌⠐⢅⢑⠐⢌⠢⡑⠌⡌⡊⡾⡯⣗⠜⡌⢆⢣⠪⡨⠢⣱⡟⢌⠂⢕⠨⡂⠅⠕⢅⢑⢐⢌⢂⢢⣡⣕⣎⢦⢇⢮⠢⠡⡃⡪⠢⡑⢌⠢⡑⢌⠢⠣⡑⢜⠌⢆⢕⠸⡨⢢⢣⢳⡹⡕⣇⢏⡯⡯⡯⣳⢯⣫⢺⢜⢮⡳⣝⣜⢮⢣⡳⣕⢝⢖⢵⡹⣪⡫⣇⢯
      ⠨⢈⢐⠐⡐⠨⠠⠑⢄⢑⠐⠄⠅⢅⠑⠌⢌⢂⠢⣻⣝⡿⡌⠌⢌⠢⡣⢱⣹⣗⢃⠢⡑⠄⢕⠨⠨⡊⠢⡑⡐⢔⢰⣳⢷⣕⣗⡝⡵⡕⢯⠨⡂⡪⠨⡊⡢⡑⢌⠢⡑⡑⢌⠢⡑⡑⡌⡪⡘⢜⢜⡕⡧⣫⢪⢮⢺⣫⢯⣏⡗⣎⢗⣝⢕⢧⡳⡪⡮⣣⢳⢕⡽⡕⡧⡫⡮⡺⣜⢮
      ⢐⠐⡐⢐⠠⠡⠈⠌⡐⠠⢁⠅⠅⡂⠅⡑⢐⠠⠡⣗⢷⣝⡧⠡⠡⡱⡘⣼⣳⢗⡅⢕⠨⡈⠢⠡⡑⠌⢌⢂⢊⢢⣟⣞⣿⣳⢵⢝⠼⡕⣝⡕⢌⢌⢊⠢⡂⡪⠢⡑⢌⢌⠢⡑⢌⠢⡊⢆⠕⡕⣇⢯⢺⢜⢕⡕⡧⣫⣗⢷⡹⣜⢵⡱⣝⢵⡹⣪⡺⣪⢣⡳⡵⡝⣎⢗⣝⢮⣗⢯
      ⠄⡂⢂⠂⠌⡐⠡⢁⠂⠅⡂⠌⡐⠠⢡⠂⠅⡊⠢⠩⡳⣳⢽⡘⢌⢢⣺⢽⢊⢏⢯⡢⢑⠌⢌⢂⠪⡨⡂⢆⢱⣝⢾⢿⣾⢯⣻⡪⡝⣞⢢⡗⡕⡐⡅⠕⢌⢌⠪⡨⡂⠆⢕⢌⠢⡃⢎⠢⡣⡱⡕⡧⡳⡹⡜⣎⢞⣺⡺⣽⡺⡪⣎⢞⡜⡮⣺⡪⡺⣜⢵⡹⣪⡺⣜⣗⡽⣕⡯⣏
      ⢐⢐⢐⠨⢐⠠⡁⠢⠨⢐⠠⡁⡂⢅⠢⠹⢦⡨⡈⠢⢑⢕⢗⠕⢠⢳⢙⢐⢐⡸⣕⢯⠐⠌⡂⡢⡑⡐⢌⢢⣳⣯⣯⣟⢝⢔⡷⡕⣝⢼⢘⢎⢎⢪⠨⡊⢆⢢⠱⡰⡘⢌⠆⢆⠣⡪⡘⡌⢆⢇⢗⢵⢹⢪⢺⢸⢪⡺⣺⢵⢯⡣⡳⣕⢝⢮⡳⣝⢝⢮⡻⣺⣳⢯⢗⣗⡽⡮⣻⣪
      ⡰⡐⡆⢎⠢⡣⡢⡣⡱⡨⡒⡌⢎⢎⠪⡪⡪⡹⣺⢬⢠⢀⡱⣕⢮⢂⢰⢰⢫⢸⢸⢪⢈⢂⢂⢂⡂⠪⡐⣼⢮⣳⡟⡊⡂⣳⣝⢮⢪⠇⢝⡗⢕⣅⢣⢑⠕⡌⡪⢢⢑⢅⠣⡑⢕⠌⡆⢕⢕⢕⢇⢗⢝⡜⣕⢝⡜⡮⡯⡯⡷⡝⣎⢮⡫⣮⣻⣺⢝⣗⡽⣳⢽⢯⢯⡺⣺⢝⡮⣞
      ⠪⡘⡸⡰⡑⢌⢆⢣⢊⢆⢇⢇⢇⢇⢣⢱⢑⠕⣜⠜⢑⠑⢜⡎⠯⠊⡂⢎⡮⡺⡸⡸⢐⢐⢰⡳⡅⣱⣸⡫⣷⢗⠱⡨⢪⣞⢼⢸⡸⡎⢦⡪⡂⡇⢆⢕⢑⢌⠪⡢⡑⢌⢪⢘⢔⠱⡘⡜⡜⡎⡇⡏⣎⢮⢪⡺⣸⢝⡾⡽⣹⢽⡸⣕⡽⣺⣺⣺⢽⢮⢫⡯⡿⡽⣕⢯⡳⡽⣺⢵
      ⡡⡱⡱⡘⢜⢌⢆⢇⢎⢎⢆⢕⢕⢕⢱⢸⢨⢪⢱⡑⡆⠌⡜⢌⢂⢕⢆⠅⡕⡯⡣⡣⡑⢔⠸⣞⣽⢜⡮⣟⢞⠰⡑⢌⡯⡮⡣⡇⣇⢥⣑⡕⣍⠪⠢⡡⠱⡨⡊⡢⡑⠕⢔⠱⡨⢪⢪⢪⢪⡪⡺⡸⡜⡜⣎⢞⡮⡷⡽⣝⢮⢟⡮⣺⡺⡵⣳⢽⢽⢽⢵⢯⢿⣝⡮⣗⡽⡽⣵⣻
      ⢜⢜⢼⢸⢸⡰⡱⡕⣎⢮⡢⡱⡑⡕⢕⠕⡥⡳⡕⢕⠕⣕⢇⢇⡇⢜⢵⢝⢮⢑⢜⠰⠨⠢⡑⢝⣯⡿⢝⢌⠢⡑⢌⣞⣝⢎⠧⡫⡞⢔⢸⡫⡌⢣⠣⡊⡪⠢⡑⢌⢜⢘⢌⢪⢸⢸⢸⢸⢸⢸⢪⢪⢎⢧⢳⢍⢯⢯⣻⣺⢵⢯⣻⡪⣞⡽⣳⢽⢯⢯⣫⢯⣟⣞⢾⢵⣫⢯⢾⣺
      ⡪⡳⡝⣎⣗⢝⢮⢫⡪⡎⣞⢕⢧⢣⠣⡝⡎⡧⡣⡑⢈⢎⢎⢞⢜⠜⡜⡵⡫⡬⡢⣑⣅⡃⡊⡂⡂⡊⢆⠢⡑⣌⡾⡜⡮⡳⡱⡑⢌⠢⡱⣫⢆⠑⢅⠪⡨⠪⡨⠢⡑⢌⠢⡱⡱⡱⡕⡕⣕⢵⢱⡣⡳⡕⣗⢝⡎⡟⡾⡽⡽⡽⣎⢯⣺⢽⡵⣟⣽⢯⢞⣗⣷⣫⢯⢷⢽⢽⢽⣺
      ⡪⡫⡮⡳⣕⡏⣗⢵⢕⣝⢜⢮⡫⣳⢕⡇⡯⡺⡪⡪⡪⡪⡪⡪⡪⡪⡪⣞⢕⢕⢇⡇⡇⡯⡳⣳⣲⣔⢄⢂⠌⣺⢮⠳⡑⢅⠅⡌⡐⡨⣺⣵⢧⢅⠀⠳⡨⠪⡨⠪⡨⠢⡑⡕⡕⡵⡹⡜⣎⢮⡣⣫⢪⡳⣕⢗⡝⣎⢯⢯⢯⣻⣪⢟⣞⢷⢽⢽⣺⢯⣻⣺⣺⢾⢽⢽⢽⢽⢽⣺
      ⡪⣳⢝⣝⢮⡺⡵⣝⢮⣪⡳⣳⡹⣪⡳⣝⢼⡪⡳⡳⣕⢵⢱⡱⡱⡱⣱⡣⡇⡇⢇⢎⢪⢪⢺⢸⢜⢮⣻⢦⢣⡳⡲⣝⢮⣳⣽⣭⢯⣺⢽⢝⣷⡹⣲⢤⣁⠣⠨⠪⠨⠨⡸⡸⡸⣪⡣⣏⢞⡼⡪⡪⡧⣫⢮⢺⡪⡺⡪⡯⣻⢺⡺⣝⢾⢽⢝⡽⣞⣟⣞⣞⣞⣯⢟⡽⡽⣽⢽⣺
      ⡪⣗⣝⢮⡳⣝⣞⢮⡳⡵⣝⢮⡺⡵⣝⢮⡳⣹⢜⢽⡸⣪⢗⢵⣫⢪⢲⢕⢯⢪⠪⡪⡪⡪⡪⡪⣪⢳⢕⣗⢷⢝⢮⢪⢮⣺⡺⣪⢫⢝⢜⢝⢮⡻⣞⢷⠽⡵⣕⢬⢦⢧⢶⢜⣬⡪⣪⢞⡵⡳⡹⡘⣝⢮⢪⡣⡫⣎⢗⣝⢮⢣⢏⢾⢝⣗⡯⣟⡾⣺⣺⣺⣺⢽⡽⣽⣫⡯⣟⡾
      ⢝⡞⡮⣳⢽⡺⣜⢗⡽⣝⣞⢽⢺⢝⡮⣳⢝⡮⣳⡣⡯⣪⢯⡳⣕⢗⢝⡽⡸⡰⡱⡑⡕⡜⢜⢜⡼⣽⣽⢽⢽⣕⡯⣯⣻⠪⠹⣎⢧⡳⣕⢽⠱⡯⣎⢧⡫⣎⢷⡝⡽⡽⡝⡝⣜⢮⢳⡳⡝⣜⢎⢆⠑⡝⡮⣪⡳⡱⡱⡪⡪⣊⢊⢈⠑⠧⡯⣳⣻⣳⣳⡳⣯⣻⡽⣳⣳⢯⡷⣻
      ⢳⡹⣝⢮⡳⣝⡮⡯⣺⡪⣞⢎⣗⣝⢮⡳⣫⢞⣕⢗⡽⣜⡵⣝⢮⡳⡝⣎⢎⢎⢪⠪⡪⡪⣮⢿⣽⣷⣟⣯⡿⣞⣯⡷⣇⡯⣪⡘⣳⡽⣮⡳⢁⢊⡯⣷⣝⣞⢮⣻⣪⢪⢪⣪⢺⡪⣳⡹⣪⢺⡸⡪⡂⡈⠺⢸⠘⠌⢌⢂⢇⢧⠱⡐⡠⢈⠺⡜⡮⣺⢮⢯⣗⣷⣻⢽⣞⡯⣯⢿
      ⢕⡝⡮⡳⡽⣕⢯⢞⣗⣝⢮⡳⣕⢧⡳⣝⢮⡳⡳⣝⢮⡺⣺⣪⡳⣝⢞⣾⢯⢣⣣⣳⡽⣽⣯⣿⣿⢷⣻⣷⡿⣫⢯⡻⡶⡟⡆⢇⠂⢫⢿⡧⣳⣝⡾⣮⣿⣾⣻⣎⢷⢝⢮⡪⡧⡫⡮⡺⣜⢵⢝⢵⢱⠠⡂⡐⠌⡊⢆⠅⢯⢎⢗⢕⢌⢆⢂⠱⡹⣪⢯⣗⡷⣳⡯⣟⡾⣽⢽⣽
      ⡪⡮⡳⣕⣝⢮⣫⡳⣕⢗⣗⢽⣪⢗⡽⡮⣳⢽⣹⡪⣗⢽⡺⣜⢾⢕⣯⣺⡽⣗⣿⣺⣟⣿⣽⣿⣯⣿⣿⣿⣟⢌⠌⡊⡘⢈⠃⠡⢈⠠⠑⣟⠺⡽⣝⢾⣻⣿⣿⡾⣝⣯⢺⡪⣳⢹⡪⣺⣪⢳⢝⣕⢇⢇⢢⢂⠁⠄⠠⢈⠘⣎⢧⢣⢣⢕⢌⡂⢝⢮⣳⣳⣻⣳⣻⣳⣻⢽⢽⣺
      ⢮⢎⢯⢎⡞⣜⢖⣝⢮⡳⣕⢯⢮⢯⢞⡽⣪⢷⢕⡯⣺⢵⡫⣞⢵⣫⢞⡼⡝⡝⢯⢻⡛⡏⢯⡷⣿⣻⣿⣽⣿⣎⢆⢆⢂⠢⡈⠄⠧⡢⢁⠄⠅⡊⠌⢕⣿⡿⣾⣿⣟⡾⣕⢕⢧⢳⡹⡜⣎⢗⡝⣎⢯⢺⡸⡰⡡⢅⢅⠂⢄⠸⣪⡫⡎⡎⡆⡕⡐⣕⢗⣗⣯⢾⡽⣞⡽⡽⡽⣮
      ⡸⡵⡝⡮⣺⢸⢕⡕⡧⣫⢞⣝⢮⣳⣫⢾⣹⢵⡫⣞⡵⣫⢞⡵⣝⢮⡳⣝⢎⢪⠪⡢⡣⡣⣻⣟⣿⣿⣻⣿⣻⣿⣷⣵⢥⢅⠍⠭⡓⡮⠲⡈⢆⢪⣪⣾⣿⣟⣿⣻⣯⣿⡽⣞⢜⢎⢮⢺⡸⡱⡹⡸⡸⡱⡱⡱⡱⡱⡡⡑⠀⠂⣇⢯⡪⡪⡪⡪⡂⡪⡯⣞⣞⣯⢟⣷⢽⢽⣽⣻
      ⢮⡳⣝⡞⡮⡳⣕⢝⢮⢎⡗⡵⣫⡺⡼⣕⣗⢗⣝⢮⢯⢎⢇⢏⢎⢇⢯⢎⢪⢢⠣⡣⡱⡱⣿⣻⣽⣾⣿⣻⣟⣯⣿⣿⣟⡷⣽⣰⢰⣸⣼⣮⣷⣿⣿⣿⣟⣯⣿⣽⡿⣷⣻⡯⡳⣹⢸⢱⢱⢱⢑⠕⢜⠌⡌⡪⡈⡂⠢⢨⢠⢪⢸⣪⢺⢜⢜⢔⢕⠌⡯⣻⡺⡽⣝⣗⣟⣽⣺⣺
      ⣳⣫⡳⣝⣞⣯⡿⣽⣯⢷⡿⣽⣗⣯⣿⣺⣞⣿⣺⣽⢷⣻⣽⢷⣱⢱⢱⢇⢣⢱⠱⡑⡕⣽⣟⣿⣻⣿⣽⣿⣿⢿⠟⡗⡵⣍⢕⢳⢯⣳⢽⢯⢿⣻⣿⣟⣿⣿⣟⣷⣏⡧⣗⡵⣹⢜⡜⣜⡼⡼⣜⣝⣜⢕⢇⢇⢧⡳⣫⢳⡹⡜⣜⢎⣗⢽⡱⡳⣱⢵⣻⣺⡮⡯⣷⣻⣞⣷⣻⣾
      ⡿⣮⡫⣞⣝⣽⣿⣻⣾⢿⣻⣫⢫⢻⢺⢻⣽⡷⣟⣿⣻⢿⡽⡹⡸⡸⡸⡕⡱⡑⢕⠱⣸⢷⣟⣯⡿⣷⢿⢳⡹⣪⢯⣪⢺⡸⣹⢨⣳⠨⡯⡳⡵⣗⣝⢿⣯⣿⣿⣽⣾⣻⣽⡽⣽⣝⢮⣗⣯⣟⣗⣟⣞⢯⢯⢯⣳⢽⣪⣗⣽⡺⣮⣳⢳⡳⣕⣝⢵⣫⢟⣾⡻⣪⡺⣜⣯⣯⢷⡷
      ⣯⣗⣽⣺⢾⣽⢾⣻⡺⣵⡳⣕⡯⡮⣇⢗⣝⡿⣯⡷⣟⣯⡇⡇⡇⡇⡇⡇⢇⣎⢎⣪⢾⣻⣽⢯⡫⡮⢪⡺⣽⣺⣻⣝⢧⢹⡪⣇⢷⢭⢯⡇⡯⣗⢯⢶⡱⠽⣾⢿⡾⣞⣮⢮⡪⣪⣳⣳⢳⡳⡲⡲⡸⡨⡳⣕⢧⣫⢳⢝⡞⣝⢮⢮⡳⣽⣺⡺⣽⡺⣽⢽⢽⢮⡺⡮⡷⡯⡿⣝
      ⣷⣳⣯⢿⡽⣯⣟⣷⢽⣾⣺⢷⡽⣽⣺⣳⡵⣟⣷⣟⣯⡷⣟⢜⢜⢜⢜⢜⢔⢺⢽⣞⡏⢝⠚⣕⢝⣜⡵⣟⣾⣯⣷⣯⣗⢵⢝⢮⣺⣝⢽⡺⣜⣯⢯⣳⡻⡝⡎⡎⣍⣟⣞⣟⡾⣵⣳⢽⣳⣫⣽⡺⡝⣜⢜⣮⣳⣳⣝⣗⣟⡮⣗⣯⣞⣗⡷⣽⡳⡯⣷⣻⢽⣻⣞⡿⣝⣯⢯⣗
      ⡷⣟⡾⣯⣟⣷⣻⢾⣻⡾⣽⡯⣿⡽⣾⢷⣻⣟⣾⣳⡯⣿⢽⣽⣺⣼⢾⡮⣮⣎⢎⠪⡙⡰⡨⢨⠹⣺⣻⣽⡿⣾⣻⣺⣪⢪⡯⣟⡎⣷⢱⣻⣪⢿⣟⣗⡕⡌⣮⢞⢔⡪⡷⡯⣻⣞⢾⢽⣺⣺⢶⣜⣜⣎⣞⣾⣺⣞⣾⣺⢾⢽⡽⣞⣞⣗⣯⢷⣻⣽⣳⢯⡯⣗⡯⣟⣽⢽⣫⢷
      ⢽⢯⣟⣷⣻⢾⡽⣿⢽⣯⢷⣟⣯⡿⣽⢯⣷⣻⣞⣷⣻⢯⣟⣷⣻⣞⡯⣟⣗⣯⢸⢺⢪⣢⣫⣾⣜⢮⢞⣗⣯⣳⣳⣳⢯⢷⣟⣗⣇⢿⡸⣺⣳⢫⣿⣞⡾⣽⣟⣯⢿⢞⡮⣯⢷⢯⢿⢽⣳⢯⣷⣳⣟⣮⢷⣳⣗⣷⣳⢯⡿⣽⡽⣽⢞⣗⡯⣟⣗⡷⣯⢿⡽⣽⢽⣳⢯⣻⣺⣻
      ⡻⡝⣾⡺⡽⣯⢿⣽⣻⢾⣻⣽⢾⡯⣿⡽⣾⣳⣟⣾⡽⣯⣷⣻⢾⣺⡯⣟⡾⡽⣽⢽⣳⢯⣻⣽⢿⡽⣽⣺⣺⣺⣺⡾⣫⡇⢷⢕⡷⡱⣯⡚⣞⡮⣫⣷⣿⣿⣻⣾⣻⢿⢽⡽⡽⡯⡿⣽⢽⣽⣺⣞⣾⣺⢯⣗⣟⢾⣝⡯⡯⣗⣯⢯⢏⢮⢝⣗⣯⣻⣞⡯⣯⢯⡻⡮⡣⠡⡣⡳
      ⣝⢎⢖⢽⣫⢯⣟⡾⣽⢯⣿⣺⢿⡽⣗⡏⣧⣻⣞⣷⣻⢗⣟⣾⣻⣳⣟⢿⢽⢯⡷⣻⣺⢽⣺⣺⣻⣽⣳⣻⣞⣾⡯⡿⡽⡼⣹⡕⣏⢗⢵⣳⢱⣫⢗⡽⣹⣟⡾⣳⢽⢯⣗⡯⣟⡽⡽⡾⣽⣺⣺⣺⣺⡺⣽⣺⣺⡳⣳⢯⢯⣗⡯⣟⢮⣳⢽⣺⣞⣞⣞⢾⢵⡫⡯⡺⣜⣕⢕⣝
      ⣪⢷⢽⣕⢷⣝⣞⡽⣽⢽⣞⡾⡯⡯⣷⣻⣳⣗⣯⢾⣺⢯⣟⣞⡾⡵⡯⡯⣯⣻⡺⡯⣯⡻⡮⣷⢯⢿⡿⣽⣾⢷⣻⡣⡋⡻⣺⣪⢯⢇⡇⣟⣎⢎⢧⢫⢮⣾⣽⢾⣯⣳⣳⢽⢵⢯⢯⣻⡺⣺⡪⣞⢮⣻⡪⣞⢮⢞⣗⢯⣳⡳⡽⣝⢽⣺⣫⡳⣻⢺⣓⢏⢟⢞⡽⣝⢮⢾⢵⣝
      ⢯⢯⣗⠯⣷⣳⣳⢿⡽⣯⢾⡽⣽⣫⣗⢷⣳⣳⢽⢽⣺⢽⡺⡮⡯⡯⣯⣻⡺⡮⡯⡯⣺⢽⢝⡾⣝⢗⢯⣳⡫⡿⣷⣷⡮⣜⡔⣎⢎⢇⢧⢣⡿⡮⣮⢯⣟⣾⣺⣝⡮⡺⣜⣝⢭⡳⣛⡞⡮⡳⣝⢮⡳⡵⣝⢮⣫⡳⡳⣝⢮⢮⡳⡽⣕⣗⢗⡽⣳⢽⡺⡽⡽⡽⣹⢝⣞⢽⡳⡵
      ⣫⢯⢆⡇⣗⢟⡞⡽⣝⡽⣳⢝⣞⢮⡺⣝⢮⡺⡽⣝⢾⢽⢝⡽⣝⢽⡪⣞⢮⣻⡪⡯⣞⣵⣻⡺⡮⣯⣗⣗⡯⣟⣷⢯⣯⢾⡮⣷⡽⣽⢽⣿⣽⡾⣯⡿⣽⣞⣷⢯⡿⣝⡮⣮⣳⣝⣞⢮⡫⡯⣺⢵⢝⣞⢮⡳⡵⣝⣝⢮⡳⣝⡮⡯⣺⣪⢯⣻⡺⣽⡺⡽⣺⢽⢕⣟⢮⢧⢹⡺
      ⡕⡧⡳⡹⣜⢵⢝⢮⡺⡼⣕⢯⢞⢵⢻⡪⣗⢯⡫⣞⢽⢹⡹⣪⢳⢝⢮⢳⢳⢕⢽⡹⣪⢺⢜⢮⢯⡺⣪⢯⡿⣯⢿⡽⣾⣻⡽⣷⣻⢯⡿⣷⣟⡿⣯⢿⣽⣞⣯⣟⣟⣯⣟⣷⣳⢻⡺⣕⢯⢫⢮⡳⣝⣮⡺⣪⣳⡣⣗⡽⣺⢕⡷⣝⣞⢮⣳⡳⡽⡮⡯⡯⣳⢯⢕⢕⡙⡎⡎⠮
      ⢯⡪⣳⢹⢜⢎⢗⢝⢜⢕⠵⡕⣝⢭⢣⢫⢪⢪⡪⡎⡎⡇⡏⡎⡇⡗⡝⡜⡕⡝⡜⡜⡜⡜⢎⢇⢏⢎⢏⢽⣽⣯⣷⣻⢞⣾⣺⣳⢯⢿⢽⢯⣿⣻⣽⣟⣷⣿⡪⡣⡫⡪⡪⡺⡸⡹⡪⣳⢹⡹⡕⡏⣖⠷⢽⢕⢷⢝⣗⢯⢷⡻⣞⢾⡪⡷⡵⡝⣞⡺⣪⡫⡮⡫⣫⢣⢝⢼⢬⢣
      ⡎⡞⡜⡜⡜⡎⡮⡪⡪⡣⡫⡪⡒⡕⡕⡕⡕⡕⡜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢌⢎⢜⢜⢜⢜⢜⢜⢜⢻⢻⢺⢳⢣⢣⢣⢪⢪⢣⢫⢣⢫⢪⢍⢏⢝⢝⢜⢎⢎⢎⢎⢎⢎⢎⢎⢮⢪⡣⡳⡱⡱⡱⡩⡣⡣⡳⡱⡪⡎⣇⢧⢳⢱⡹⣸⡪⡺⣪⢺⢪⢺⡸⡱⣕⢝⡜⣕⢝⡎
      ⢣⢣⢣⠫⡪⡚⡜⡪⢪⠪⡪⢪⢚⢪⠪⡚⡜⢜⢸⢘⢔⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⡱⡑⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡝⡜⡕⣕⢕⢕⢕⢕⢝⢼⢸⢸⢸⢸⢸⢸⢱⢱⡱⡱⡱⡱⡹⡸⡪⡣⡳⡱⡹⡸⡸⡸⡸⡜⣎⢮⢣⡳

      ⠡⡡⢡⠑⢅⠣⡑⢕⠱⡱⡩⡪⡪⡱⡱⡩⡪⡪⣱⢕⢍⢎⢎⢎⢎⠪⡊⢎⠪⣊⠪⣊⠪⡊⡪⡊⡪⡊⢎⢊⠪⡊⢎⠪⠪⡪⡊⢎⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡫⡝⡭⣫⢯⠯⡯⣏⢯⣫⣫⣝⣝⢽⢽⢝⡽⢭⡫⣫⡫⡳⣹⢹⣹⡹⡭⡫⣝⢵
      ⢂⢊⠢⠡⡡⡑⢌⠢⡑⢌⠪⡪⢪⠪⡪⢪⠪⡪⡪⣷⢑⢕⠕⡕⢕⢕⢱⢑⢕⢢⠣⡢⣃⢇⢪⠨⠢⡊⡢⡑⡑⢌⠢⡑⡑⢌⢌⠢⡑⢌⠢⡣⠱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡡⡃⢎⠢⡃⡇⣏⢮⢗⣯⢯⡺⡪⣇⢗⢮⣞⢮⣗⢯⣳⡫⣗⢽⡪⡮⡳⣕⢽⢜⢮⡪⣇⢗⢵
      ⢂⠢⠡⡑⡐⠨⡐⡑⢌⠢⡑⢜⠸⡘⡜⢌⢎⢪⠪⣟⣎⢆⢇⢣⢣⠱⡡⡣⡑⡅⢇⢪⡞⢌⠢⡑⢅⢕⢐⠕⢌⠢⡑⢌⢌⠢⠢⡑⢌⠢⡑⠜⡌⡪⡘⡌⢎⢜⢌⢎⢜⢌⢎⠜⡔⡑⡌⡪⡘⡌⡪⣪⢏⢮⢯⣗⡯⣳⢵⢝⣞⢮⣗⢽⢕⣗⢽⣪⡳⡝⡮⡺⣜⢮⢳⡣⡳⣕⣝⢵
      ⢐⠨⢂⠢⡈⡂⡢⠨⡂⢕⠨⠢⡑⡑⢌⠢⡑⢕⠱⡽⡵⡕⡅⢇⢪⠪⡢⡑⢕⢘⢬⡟⢌⠢⡑⢌⠢⠢⢡⠡⡡⡑⢌⢂⠢⠡⡑⢌⠢⡑⢌⢊⠢⡑⢌⠪⡘⢔⠱⡨⢢⠣⡊⡎⢜⢌⠆⡕⢌⢪⢸⢸⢝⢎⢧⡳⡯⡯⣫⢗⣗⢯⢮⣫⡳⣕⢗⣕⢧⢫⡺⣪⡺⣪⡣⡏⣞⢎⢮⡺
      ⠐⠨⢐⢐⢐⠐⢌⠐⢌⠐⢅⢑⠐⢌⠢⡑⠌⡌⡊⡾⡯⣗⠜⡌⢆⢣⠪⡨⠢⣱⡟⢌⠂⢕⠨⡂⠅⠕⢅⢑⢐⢌⢂⢢⣡⣕⣎⢦⢇⢮⠢⠡⡃⡪⠢⡑⢌⠢⡑⢌⠢⠣⡑⢜⠌⢆⢕⠸⡨⢢⢣⢳⡹⡕⣇⢏⡯⡯⡯⣳⢯⣫⢺⢜⢮⡳⣝⣜⢮⢣⡳⣕⢝⢖⢵⡹⣪⡫⣇⢯
      ⠨⢈⢐⠐⡐⠨⠠⠑⢄⢑⠐⠄⠅⢅⠑⠌⢌⢂⠢⣻⣝⡿⡌⠌⢌⠢⡣⢱⣹⣗⢃⠢⡑⠄⢕⠨⠨⡊⠢⡑⡐⢔⢰⣳⢷⣕⣗⡝⡵⡕⢯⠨⡂⡪⠨⡊⡢⡑⢌⠢⡑⡑⢌⠢⡑⡑⡌⡪⡘⢜⢜⡕⡧⣫⢪⢮⢺⣫⢯⣏⡗⣎⢗⣝⢕⢧⡳⡪⡮⣣⢳⢕⡽⡕⡧⡫⡮⡺⣜⢮
      ⢐⠐⡐⢐⠠⠡⠈⠌⡐⠠⢁⠅⠅⡂⠅⡑⢐⠠⠡⣗⢷⣝⡧⠡⠡⡱⡘⣼⣳⢗⡅⢕⠨⡈⠢⠡⡑⠌⢌⢂⢊⢢⣟⣞⣿⣳⢵⢝⠼⡕⣝⡕⢌⢌⢊⠢⡂⡪⠢⡑⢌⢌⠢⡑⢌⠢⡊⢆⠕⡕⣇⢯⢺⢜⢕⡕⡧⣫⣗⢷⡹⣜⢵⡱⣝⢵⡹⣪⡺⣪⢣⡳⡵⡝⣎⢗⣝⢮⣗⢯
      ⠄⡂⢂⠂⠌⡐⠡⢁⠂⠅⡂⠌⡐⠠⢡⠂⠅⡊⠢⠩⡳⣳⢽⡘⢌⢢⣺⢽⢊⢏⢯⡢⢑⠌⢌⢂⠪⡨⡂⢆⢱⣝⢾⢿⣾⢯⣻⡪⡝⣞⢢⡗⡕⡐⡅⠕⢌⢌⠪⡨⡂⠆⢕⢌⠢⡃⢎⠢⡣⡱⡕⡧⡳⡹⡜⣎⢞⣺⡺⣽⡺⡪⣎⢞⡜⡮⣺⡪⡺⣜⢵⡹⣪⡺⣜⣗⡽⣕⡯⣏
      ⢐⢐⢐⠨⢐⠠⡁⠢⠨⢐⠠⡁⡂⢅⠢⠹⢦⡨⡈⠢⢑⢕⢗⠕⢠⢳⢙⢐⢐⡸⣕⢯⠐⠌⡂⡢⡑⡐⢌⢢⣳⣯⣯⣟⢝⢔⡷⡕⣝⢼⢘⢎⢎⢪⠨⡊⢆⢢⠱⡰⡘⢌⠆⢆⠣⡪⡘⡌⢆⢇⢗⢵⢹⢪⢺⢸⢪⡺⣺⢵⢯⡣⡳⣕⢝⢮⡳⣝⢝⢮⡻⣺⣳⢯⢗⣗⡽⡮⣻⣪
      ⡰⡐⡆⢎⠢⡣⡢⡣⡱⡨⡒⡌⢎⢎⠪⡪⡪⡹⣺⢬⢠⢀⡱⣕⢮⢂⢰⢰⢫⢸⢸⢪⢈⢂⢂⢂⡂⠪⡐⣼⢮⣳⡟⡊⡂⣳⣝⢮⢪⠇⢝⡗⢕⣅⢣⢑⠕⡌⡪⢢⢑⢅⠣⡑⢕⠌⡆⢕⢕⢕⢇⢗⢝⡜⣕⢝⡜⡮⡯⡯⡷⡝⣎⢮⡫⣮⣻⣺⢝⣗⡽⣳⢽⢯⢯⡺⣺⢝⡮⣞
      ⠪⡘⡸⡰⡑⢌⢆⢣⢊⢆⢇⢇⢇⢇⢣⢱⢑⠕⣜⠜⢑⠑⢜⡎⠯⠊⡂⢎⡮⡺⡸⡸⢐⢐⢰⡳⡅⣱⣸⡫⣷⢗⠱⡨⢪⣞⢼⢸⡸⡎⢦⡪⡂⡇⢆⢕⢑⢌⠪⡢⡑⢌⢪⢘⢔⠱⡘⡜⡜⡎⡇⡏⣎⢮⢪⡺⣸⢝⡾⡽⣹⢽⡸⣕⡽⣺⣺⣺⢽⢮⢫⡯⡿⡽⣕⢯⡳⡽⣺⢵
      ⡡⡱⡱⡘⢜⢌⢆⢇⢎⢎⢆⢕⢕⢕⢱⢸⢨⢪⢱⡑⡆⠌⡜⢌⢂⢕⢆⠅⡕⡯⡣⡣⡑⢔⠸⣞⣽⢜⡮⣟⢞⠰⡑⢌⡯⡮⡣⡇⣇⢥⣑⡕⣍⠪⠢⡡⠱⡨⡊⡢⡑⠕⢔⠱⡨⢪⢪⢪⢪⡪⡺⡸⡜⡜⣎⢞⡮⡷⡽⣝⢮⢟⡮⣺⡺⡵⣳⢽⢽⢽⢵⢯⢿⣝⡮⣗⡽⡽⣵⣻
      ⢜⢜⢼⢸⢸⡰⡱⡕⣎⢮⡢⡱⡑⡕⢕⠕⡥⡳⡕⢕⠕⣕⢇⢇⡇⢜⢵⢝⢮⢑⢜⠰⠨⠢⡑⢝⣯⡿⢝⢌⠢⡑⢌⣞⣝⢎⠧⡫⡞⢔⢸⡫⡌⢣⠣⡊⡪⠢⡑⢌⢜⢘⢌⢪⢸⢸⢸⢸⢸⢸⢪⢪⢎⢧⢳⢍⢯⢯⣻⣺⢵⢯⣻⡪⣞⡽⣳⢽⢯⢯⣫⢯⣟⣞⢾⢵⣫⢯⢾⣺
      ⡪⡳⡝⣎⣗⢝⢮⢫⡪⡎⣞⢕⢧⢣⠣⡝⡎⡧⡣⡑⢈⢎⢎⢞⢜⠜⡜⡵⡫⡬⡢⣑⣅⡃⡊⡂⡂⡊⢆⠢⡑⣌⡾⡜⡮⡳⡱⡑⢌⠢⡱⣫⢆⠑⢅⠪⡨⠪⡨⠢⡑⢌⠢⡱⡱⡱⡕⡕⣕⢵⢱⡣⡳⡕⣗⢝⡎⡟⡾⡽⡽⡽⣎⢯⣺⢽⡵⣟⣽⢯⢞⣗⣷⣫⢯⢷⢽⢽⢽⣺
      ⡪⡫⡮⡳⣕⡏⣗⢵⢕⣝⢜⢮⡫⣳⢕⡇⡯⡺⡪⡪⡪⡪⡪⡪⡪⡪⡪⣞⢕⢕⢇⡇⡇⡯⡳⣳⣲⣔⢄⢂⠌⣺⢮⠳⡑⢅⠅⡌⡐⡨⣺⣵⢧⢅⠀⠳⡨⠪⡨⠪⡨⠢⡑⡕⡕⡵⡹⡜⣎⢮⡣⣫⢪⡳⣕⢗⡝⣎⢯⢯⢯⣻⣪⢟⣞⢷⢽⢽⣺⢯⣻⣺⣺⢾⢽⢽⢽⢽⢽⣺
      ⡪⣳⢝⣝⢮⡺⡵⣝⢮⣪⡳⣳⡹⣪⡳⣝⢼⡪⡳⡳⣕⢵⢱⡱⡱⡱⣱⡣⡇⡇⢇⢎⢪⢪⢺⢸⢜⢮⣻⢦⢣⡳⡲⣝⢮⣳⣽⣭⢯⣺⢽⢝⣷⡹⣲⢤⣁⠣⠨⠪⠨⠨⡸⡸⡸⣪⡣⣏⢞⡼⡪⡪⡧⣫⢮⢺⡪⡺⡪⡯⣻⢺⡺⣝⢾⢽⢝⡽⣞⣟⣞⣞⣞⣯⢟⡽⡽⣽⢽⣺
      ⡪⣗⣝⢮⡳⣝⣞⢮⡳⡵⣝⢮⡺⡵⣝⢮⡳⣹⢜⢽⡸⣪⢗⢵⣫⢪⢲⢕⢯⢪⠪⡪⡪⡪⡪⡪⣪⢳⢕⣗⢷⢝⢮⢪⢮⣺⡺⣪⢫⢝⢜⢝⢮⡻⣞⢷⠽⡵⣕⢬⢦⢧⢶⢜⣬⡪⣪⢞⡵⡳⡹⡘⣝⢮⢪⡣⡫⣎⢗⣝⢮⢣⢏⢾⢝⣗⡯⣟⡾⣺⣺⣺⣺⢽⡽⣽⣫⡯⣟⡾
      ⢝⡞⡮⣳⢽⡺⣜⢗⡽⣝⣞⢽⢺⢝⡮⣳⢝⡮⣳⡣⡯⣪⢯⡳⣕⢗⢝⡽⡸⡰⡱⡑⡕⡜⢜⢜⡼⣽⣽⢽⢽⣕⡯⣯⣻⠪⠹⣎⢧⡳⣕⢽⠱⡯⣎⢧⡫⣎⢷⡝⡽⡽⡝⡝⣜⢮⢳⡳⡝⣜⢎⢆⠑⡝⡮⣪⡳⡱⡱⡪⡪⣊⢊⢈⠑⠧⡯⣳⣻⣳⣳⡳⣯⣻⡽⣳⣳⢯⡷⣻
      ⢳⡹⣝⢮⡳⣝⡮⡯⣺⡪⣞⢎⣗⣝⢮⡳⣫⢞⣕⢗⡽⣜⡵⣝⢮⡳⡝⣎⢎⢎⢪⠪⡪⡪⣮⢿⣽⣷⣟⣯⡿⣞⣯⡷⣇⡯⣪⡘⣳⡽⣮⡳⢁⢊⡯⣷⣝⣞⢮⣻⣪⢪⢪⣪⢺⡪⣳⡹⣪⢺⡸⡪⡂⡈⠺⢸⠘⠌⢌⢂⢇⢧⠱⡐⡠⢈⠺⡜⡮⣺⢮⢯⣗⣷⣻⢽⣞⡯⣯⢿
      ⢕⡝⡮⡳⡽⣕⢯⢞⣗⣝⢮⡳⣕⢧⡳⣝⢮⡳⡳⣝⢮⡺⣺⣪⡳⣝⢞⣾⢯⢣⣣⣳⡽⣽⣯⣿⣿⢷⣻⣷⡿⣫⢯⡻⡶⡟⡆⢇⠂⢫⢿⡧⣳⣝⡾⣮⣿⣾⣻⣎⢷⢝⢮⡪⡧⡫⡮⡺⣜⢵⢝⢵⢱⠠⡂⡐⠌⡊⢆⠅⢯⢎⢗⢕⢌⢆⢂⠱⡹⣪⢯⣗⡷⣳⡯⣟⡾⣽⢽⣽
      ⡪⡮⡳⣕⣝⢮⣫⡳⣕⢗⣗⢽⣪⢗⡽⡮⣳⢽⣹⡪⣗⢽⡺⣜⢾⢕⣯⣺⡽⣗⣿⣺⣟⣿⣽⣿⣯⣿⣿⣿⣟⢌⠌⡊⡘⢈⠃⠡⢈⠠⠑⣟⠺⡽⣝⢾⣻⣿⣿⡾⣝⣯⢺⡪⣳⢹⡪⣺⣪⢳⢝⣕⢇⢇⢢⢂⠁⠄⠠⢈⠘⣎⢧⢣⢣⢕⢌⡂⢝⢮⣳⣳⣻⣳⣻⣳⣻⢽⢽⣺
      ⢮⢎⢯⢎⡞⣜⢖⣝⢮⡳⣕⢯⢮⢯⢞⡽⣪⢷⢕⡯⣺⢵⡫⣞⢵⣫⢞⡼⡝⡝⢯⢻⡛⡏⢯⡷⣿⣻⣿⣽⣿⣎⢆⢆⢂⠢⡈⠄⠧⡢⢁⠄⠅⡊⠌⢕⣿⡿⣾⣿⣟⡾⣕⢕⢧⢳⡹⡜⣎⢗⡝⣎⢯⢺⡸⡰⡡⢅⢅⠂⢄⠸⣪⡫⡎⡎⡆⡕⡐⣕⢗⣗⣯⢾⡽⣞⡽⡽⡽⣮
      ⡸⡵⡝⡮⣺⢸⢕⡕⡧⣫⢞⣝⢮⣳⣫⢾⣹⢵⡫⣞⡵⣫⢞⡵⣝⢮⡳⣝⢎⢪⠪⡢⡣⡣⣻⣟⣿⣿⣻⣿⣻⣿⣷⣵⢥⢅⠍⠭⡓⡮⠲⡈⢆⢪⣪⣾⣿⣟⣿⣻⣯⣿⡽⣞⢜⢎⢮⢺⡸⡱⡹⡸⡸⡱⡱⡱⡱⡱⡡⡑⠀⠂⣇⢯⡪⡪⡪⡪⡂⡪⡯⣞⣞⣯⢟⣷⢽⢽⣽⣻
      ⢮⡳⣝⡞⡮⡳⣕⢝⢮⢎⡗⡵⣫⡺⡼⣕⣗⢗⣝⢮⢯⢎⢇⢏⢎⢇⢯⢎⢪⢢⠣⡣⡱⡱⣿⣻⣽⣾⣿⣻⣟⣯⣿⣿⣟⡷⣽⣰⢰⣸⣼⣮⣷⣿⣿⣿⣟⣯⣿⣽⡿⣷⣻⡯⡳⣹⢸⢱⢱⢱⢑⠕⢜⠌⡌⡪⡈⡂⠢⢨⢠⢪⢸⣪⢺⢜⢜⢔⢕⠌⡯⣻⡺⡽⣝⣗⣟⣽⣺⣺
      ⣳⣫⡳⣝⣞⣯⡿⣽⣯⢷⡿⣽⣗⣯⣿⣺⣞⣿⣺⣽⢷⣻⣽⢷⣱⢱⢱⢇⢣⢱⠱⡑⡕⣽⣟⣿⣻⣿⣽⣿⣿⢿⠟⡗⡵⣍⢕⢳⢯⣳⢽⢯⢿⣻⣿⣟⣿⣿⣟⣷⣏⡧⣗⡵⣹⢜⡜⣜⡼⡼⣜⣝⣜⢕⢇⢇⢧⡳⣫⢳⡹⡜⣜⢎⣗⢽⡱⡳⣱⢵⣻⣺⡮⡯⣷⣻⣞⣷⣻⣾
      ⡿⣮⡫⣞⣝⣽⣿⣻⣾⢿⣻⣫⢫⢻⢺⢻⣽⡷⣟⣿⣻⢿⡽⡹⡸⡸⡸⡕⡱⡑⢕⠱⣸⢷⣟⣯⡿⣷⢿⢳⡹⣪⢯⣪⢺⡸⣹⢨⣳⠨⡯⡳⡵⣗⣝⢿⣯⣿⣿⣽⣾⣻⣽⡽⣽⣝⢮⣗⣯⣟⣗⣟⣞⢯⢯⢯⣳⢽⣪⣗⣽⡺⣮⣳⢳⡳⣕⣝⢵⣫⢟⣾⡻⣪⡺⣜⣯⣯⢷⡷
      ⣯⣗⣽⣺⢾⣽⢾⣻⡺⣵⡳⣕⡯⡮⣇⢗⣝⡿⣯⡷⣟⣯⡇⡇⡇⡇⡇⡇⢇⣎⢎⣪⢾⣻⣽⢯⡫⡮⢪⡺⣽⣺⣻⣝⢧⢹⡪⣇⢷⢭⢯⡇⡯⣗⢯⢶⡱⠽⣾⢿⡾⣞⣮⢮⡪⣪⣳⣳⢳⡳⡲⡲⡸⡨⡳⣕⢧⣫⢳⢝⡞⣝⢮⢮⡳⣽⣺⡺⣽⡺⣽⢽⢽⢮⡺⡮⡷⡯⡿⣝
      ⣷⣳⣯⢿⡽⣯⣟⣷⢽⣾⣺⢷⡽⣽⣺⣳⡵⣟⣷⣟⣯⡷⣟⢜⢜⢜⢜⢜⢔⢺⢽⣞⡏⢝⠚⣕⢝⣜⡵⣟⣾⣯⣷⣯⣗⢵⢝⢮⣺⣝⢽⡺⣜⣯⢯⣳⡻⡝⡎⡎⣍⣟⣞⣟⡾⣵⣳⢽⣳⣫⣽⡺⡝⣜⢜⣮⣳⣳⣝⣗⣟⡮⣗⣯⣞⣗⡷⣽⡳⡯⣷⣻⢽⣻⣞⡿⣝⣯⢯⣗
      ⡷⣟⡾⣯⣟⣷⣻⢾⣻⡾⣽⡯⣿⡽⣾⢷⣻⣟⣾⣳⡯⣿⢽⣽⣺⣼⢾⡮⣮⣎⢎⠪⡙⡰⡨⢨⠹⣺⣻⣽⡿⣾⣻⣺⣪⢪⡯⣟⡎⣷⢱⣻⣪⢿⣟⣗⡕⡌⣮⢞⢔⡪⡷⡯⣻⣞⢾⢽⣺⣺⢶⣜⣜⣎⣞⣾⣺⣞⣾⣺⢾⢽⡽⣞⣞⣗⣯⢷⣻⣽⣳⢯⡯⣗⡯⣟⣽⢽⣫⢷
      ⢽⢯⣟⣷⣻⢾⡽⣿⢽⣯⢷⣟⣯⡿⣽⢯⣷⣻⣞⣷⣻⢯⣟⣷⣻⣞⡯⣟⣗⣯⢸⢺⢪⣢⣫⣾⣜⢮⢞⣗⣯⣳⣳⣳⢯⢷⣟⣗⣇⢿⡸⣺⣳⢫⣿⣞⡾⣽⣟⣯⢿⢞⡮⣯⢷⢯⢿⢽⣳⢯⣷⣳⣟⣮⢷⣳⣗⣷⣳⢯⡿⣽⡽⣽⢞⣗⡯⣟⣗⡷⣯⢿⡽⣽⢽⣳⢯⣻⣺⣻
      ⡻⡝⣾⡺⡽⣯⢿⣽⣻⢾⣻⣽⢾⡯⣿⡽⣾⣳⣟⣾⡽⣯⣷⣻⢾⣺⡯⣟⡾⡽⣽⢽⣳⢯⣻⣽⢿⡽⣽⣺⣺⣺⣺⡾⣫⡇⢷⢕⡷⡱⣯⡚⣞⡮⣫⣷⣿⣿⣻⣾⣻⢿⢽⡽⡽⡯⡿⣽⢽⣽⣺⣞⣾⣺⢯⣗⣟⢾⣝⡯⡯⣗⣯⢯⢏⢮⢝⣗⣯⣻⣞⡯⣯⢯⡻⡮⡣⠡⡣⡳
      ⣝⢎⢖⢽⣫⢯⣟⡾⣽⢯⣿⣺⢿⡽⣗⡏⣧⣻⣞⣷⣻⢗⣟⣾⣻⣳⣟⢿⢽⢯⡷⣻⣺⢽⣺⣺⣻⣽⣳⣻⣞⣾⡯⡿⡽⡼⣹⡕⣏⢗⢵⣳⢱⣫⢗⡽⣹⣟⡾⣳⢽⢯⣗⡯⣟⡽⡽⡾⣽⣺⣺⣺⣺⡺⣽⣺⣺⡳⣳⢯⢯⣗⡯⣟⢮⣳⢽⣺⣞⣞⣞⢾⢵⡫⡯⡺⣜⣕⢕⣝
      ⣪⢷⢽⣕⢷⣝⣞⡽⣽⢽⣞⡾⡯⡯⣷⣻⣳⣗⣯⢾⣺⢯⣟⣞⡾⡵⡯⡯⣯⣻⡺⡯⣯⡻⡮⣷⢯⢿⡿⣽⣾⢷⣻⡣⡋⡻⣺⣪⢯⢇⡇⣟⣎⢎⢧⢫⢮⣾⣽⢾⣯⣳⣳⢽⢵⢯⢯⣻⡺⣺⡪⣞⢮⣻⡪⣞⢮⢞⣗⢯⣳⡳⡽⣝⢽⣺⣫⡳⣻⢺⣓⢏⢟⢞⡽⣝⢮⢾⢵⣝
      ⢯⢯⣗⠯⣷⣳⣳⢿⡽⣯⢾⡽⣽⣫⣗⢷⣳⣳⢽⢽⣺⢽⡺⡮⡯⡯⣯⣻⡺⡮⡯⡯⣺⢽⢝⡾⣝⢗⢯⣳⡫⡿⣷⣷⡮⣜⡔⣎⢎⢇⢧⢣⡿⡮⣮⢯⣟⣾⣺⣝⡮⡺⣜⣝⢭⡳⣛⡞⡮⡳⣝⢮⡳⡵⣝⢮⣫⡳⡳⣝⢮⢮⡳⡽⣕⣗⢗⡽⣳⢽⡺⡽⡽⡽⣹⢝⣞⢽⡳⡵
      ⣫⢯⢆⡇⣗⢟⡞⡽⣝⡽⣳⢝⣞⢮⡺⣝⢮⡺⡽⣝⢾⢽⢝⡽⣝⢽⡪⣞⢮⣻⡪⡯⣞⣵⣻⡺⡮⣯⣗⣗⡯⣟⣷⢯⣯⢾⡮⣷⡽⣽⢽⣿⣽⡾⣯⡿⣽⣞⣷⢯⡿⣝⡮⣮⣳⣝⣞⢮⡫⡯⣺⢵⢝⣞⢮⡳⡵⣝⣝⢮⡳⣝⡮⡯⣺⣪⢯⣻⡺⣽⡺⡽⣺⢽⢕⣟⢮⢧⢹⡺
      ⡕⡧⡳⡹⣜⢵⢝⢮⡺⡼⣕⢯⢞⢵⢻⡪⣗⢯⡫⣞⢽⢹⡹⣪⢳⢝⢮⢳⢳⢕⢽⡹⣪⢺⢜⢮⢯⡺⣪⢯⡿⣯⢿⡽⣾⣻⡽⣷⣻⢯⡿⣷⣟⡿⣯⢿⣽⣞⣯⣟⣟⣯⣟⣷⣳⢻⡺⣕⢯⢫⢮⡳⣝⣮⡺⣪⣳⡣⣗⡽⣺⢕⡷⣝⣞⢮⣳⡳⡽⡮⡯⡯⣳⢯⢕⢕⡙⡎⡎⠮
      ⢯⡪⣳⢹⢜⢎⢗⢝⢜⢕⠵⡕⣝⢭⢣⢫⢪⢪⡪⡎⡎⡇⡏⡎⡇⡗⡝⡜⡕⡝⡜⡜⡜⡜⢎⢇⢏⢎⢏⢽⣽⣯⣷⣻⢞⣾⣺⣳⢯⢿⢽⢯⣿⣻⣽⣟⣷⣿⡪⡣⡫⡪⡪⡺⡸⡹⡪⣳⢹⡹⡕⡏⣖⠷⢽⢕⢷⢝⣗⢯⢷⡻⣞⢾⡪⡷⡵⡝⣞⡺⣪⡫⡮⡫⣫⢣⢝⢼⢬⢣
      ⡎⡞⡜⡜⡜⡎⡮⡪⡪⡣⡫⡪⡒⡕⡕⡕⡕⡕⡜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢌⢎⢜⢜⢜⢜⢜⢜⢜⢻⢻⢺⢳⢣⢣⢣⢪⢪⢣⢫⢣⢫⢪⢍⢏⢝⢝⢜⢎⢎⢎⢎⢎⢎⢎⢎⢮⢪⡣⡳⡱⡱⡱⡩⡣⡣⡳⡱⡪⡎⣇⢧⢳⢱⡹⣸⡪⡺⣪⢺⢪⢺⡸⡱⣕⢝⡜⣕⢝⡎
      ⢣⢣⢣⠫⡪⡚⡜⡪⢪⠪⡪⢪⢚⢪⠪⡚⡜⢜⢸⢘⢔⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⡱⡑⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡝⡜⡕⣕⢕⢕⢕⢕⢝⢼⢸⢸⢸⢸⢸⢸⢱⢱⡱⡱⡱⡱⡹⡸⡪⡣⡳⡱⡹⡸⡸⡸⡸⡜⣎⢮⢣⡳

        
⠡⡡⢡⠑⢅⠣⡑⢕⠱⡱⡩⡪⡪⡱⡱⡩⡪⡪⣱⢕⢍⢎⢎⢎⢎⠪⡊⢎⠪⣊⠪⣊⠪⡊⡪⡊⡪⡊⢎⢊⠪⡊⢎⠪⠪⡪⡊⢎⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡫⡝⡭⣫⢯⠯⡯⣏⢯⣫⣫⣝⣝⢽⢽⢝⡽⢭⡫⣫⡫⡳⣹⢹⣹⡹⡭⡫⣝⢵
⢂⢊⠢⠡⡡⡑⢌⠢⡑⢌⠪⡪⢪⠪⡪⢪⠪⡪⡪⣷⢑⢕⠕⡕⢕⢕⢱⢑⢕⢢⠣⡢⣃⢇⢪⠨⠢⡊⡢⡑⡑⢌⠢⡑⡑⢌⢌⠢⡑⢌⠢⡣⠱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡡⡃⢎⠢⡃⡇⣏⢮⢗⣯⢯⡺⡪⣇⢗⢮⣞⢮⣗⢯⣳⡫⣗⢽⡪⡮⡳⣕⢽⢜⢮⡪⣇⢗⢵
⢂⠢⠡⡑⡐⠨⡐⡑⢌⠢⡑⢜⠸⡘⡜⢌⢎⢪⠪⣟⣎⢆⢇⢣⢣⠱⡡⡣⡑⡅⢇⢪⡞⢌⠢⡑⢅⢕⢐⠕⢌⠢⡑⢌⢌⠢⠢⡑⢌⠢⡑⠜⡌⡪⡘⡌⢎⢜⢌⢎⢜⢌⢎⠜⡔⡑⡌⡪⡘⡌⡪⣪⢏⢮⢯⣗⡯⣳⢵⢝⣞⢮⣗⢽⢕⣗⢽⣪⡳⡝⡮⡺⣜⢮⢳⡣⡳⣕⣝⢵
⢐⠨⢂⠢⡈⡂⡢⠨⡂⢕⠨⠢⡑⡑⢌⠢⡑⢕⠱⡽⡵⡕⡅⢇⢪⠪⡢⡑⢕⢘⢬⡟⢌⠢⡑⢌⠢⠢⢡⠡⡡⡑⢌⢂⠢⠡⡑⢌⠢⡑⢌⢊⠢⡑⢌⠪⡘⢔⠱⡨⢢⠣⡊⡎⢜⢌⠆⡕⢌⢪⢸⢸⢝⢎⢧⡳⡯⡯⣫⢗⣗⢯⢮⣫⡳⣕⢗⣕⢧⢫⡺⣪⡺⣪⡣⡏⣞⢎⢮⡺
⠐⠨⢐⢐⢐⠐⢌⠐⢌⠐⢅⢑⠐⢌⠢⡑⠌⡌⡊⡾⡯⣗⠜⡌⢆⢣⠪⡨⠢⣱⡟⢌⠂⢕⠨⡂⠅⠕⢅⢑⢐⢌⢂⢢⣡⣕⣎⢦⢇⢮⠢⠡⡃⡪⠢⡑⢌⠢⡑⢌⠢⠣⡑⢜⠌⢆⢕⠸⡨⢢⢣⢳⡹⡕⣇⢏⡯⡯⡯⣳⢯⣫⢺⢜⢮⡳⣝⣜⢮⢣⡳⣕⢝⢖⢵⡹⣪⡫⣇⢯
⠨⢈⢐⠐⡐⠨⠠⠑⢄⢑⠐⠄⠅⢅⠑⠌⢌⢂⠢⣻⣝⡿⡌⠌⢌⠢⡣⢱⣹⣗⢃⠢⡑⠄⢕⠨⠨⡊⠢⡑⡐⢔⢰⣳⢷⣕⣗⡝⡵⡕⢯⠨⡂⡪⠨⡊⡢⡑⢌⠢⡑⡑⢌⠢⡑⡑⡌⡪⡘⢜⢜⡕⡧⣫⢪⢮⢺⣫⢯⣏⡗⣎⢗⣝⢕⢧⡳⡪⡮⣣⢳⢕⡽⡕⡧⡫⡮⡺⣜⢮
⢐⠐⡐⢐⠠⠡⠈⠌⡐⠠⢁⠅⠅⡂⠅⡑⢐⠠⠡⣗⢷⣝⡧⠡⠡⡱⡘⣼⣳⢗⡅⢕⠨⡈⠢⠡⡑⠌⢌⢂⢊⢢⣟⣞⣿⣳⢵⢝⠼⡕⣝⡕⢌⢌⢊⠢⡂⡪⠢⡑⢌⢌⠢⡑⢌⠢⡊⢆⠕⡕⣇⢯⢺⢜⢕⡕⡧⣫⣗⢷⡹⣜⢵⡱⣝⢵⡹⣪⡺⣪⢣⡳⡵⡝⣎⢗⣝⢮⣗⢯
⠄⡂⢂⠂⠌⡐⠡⢁⠂⠅⡂⠌⡐⠠⢡⠂⠅⡊⠢⠩⡳⣳⢽⡘⢌⢢⣺⢽⢊⢏⢯⡢⢑⠌⢌⢂⠪⡨⡂⢆⢱⣝⢾⢿⣾⢯⣻⡪⡝⣞⢢⡗⡕⡐⡅⠕⢌⢌⠪⡨⡂⠆⢕⢌⠢⡃⢎⠢⡣⡱⡕⡧⡳⡹⡜⣎⢞⣺⡺⣽⡺⡪⣎⢞⡜⡮⣺⡪⡺⣜⢵⡹⣪⡺⣜⣗⡽⣕⡯⣏
⢐⢐⢐⠨⢐⠠⡁⠢⠨⢐⠠⡁⡂⢅⠢⠹⢦⡨⡈⠢⢑⢕⢗⠕⢠⢳⢙⢐⢐⡸⣕⢯⠐⠌⡂⡢⡑⡐⢌⢢⣳⣯⣯⣟⢝⢔⡷⡕⣝⢼⢘⢎⢎⢪⠨⡊⢆⢢⠱⡰⡘⢌⠆⢆⠣⡪⡘⡌⢆⢇⢗⢵⢹⢪⢺⢸⢪⡺⣺⢵⢯⡣⡳⣕⢝⢮⡳⣝⢝⢮⡻⣺⣳⢯⢗⣗⡽⡮⣻⣪
⡰⡐⡆⢎⠢⡣⡢⡣⡱⡨⡒⡌⢎⢎⠪⡪⡪⡹⣺⢬⢠⢀⡱⣕⢮⢂⢰⢰⢫⢸⢸⢪⢈⢂⢂⢂⡂⠪⡐⣼⢮⣳⡟⡊⡂⣳⣝⢮⢪⠇⢝⡗⢕⣅⢣⢑⠕⡌⡪⢢⢑⢅⠣⡑⢕⠌⡆⢕⢕⢕⢇⢗⢝⡜⣕⢝⡜⡮⡯⡯⡷⡝⣎⢮⡫⣮⣻⣺⢝⣗⡽⣳⢽⢯⢯⡺⣺⢝⡮⣞
⠪⡘⡸⡰⡑⢌⢆⢣⢊⢆⢇⢇⢇⢇⢣⢱⢑⠕⣜⠜⢑⠑⢜⡎⠯⠊⡂⢎⡮⡺⡸⡸⢐⢐⢰⡳⡅⣱⣸⡫⣷⢗⠱⡨⢪⣞⢼⢸⡸⡎⢦⡪⡂⡇⢆⢕⢑⢌⠪⡢⡑⢌⢪⢘⢔⠱⡘⡜⡜⡎⡇⡏⣎⢮⢪⡺⣸⢝⡾⡽⣹⢽⡸⣕⡽⣺⣺⣺⢽⢮⢫⡯⡿⡽⣕⢯⡳⡽⣺⢵
⡡⡱⡱⡘⢜⢌⢆⢇⢎⢎⢆⢕⢕⢕⢱⢸⢨⢪⢱⡑⡆⠌⡜⢌⢂⢕⢆⠅⡕⡯⡣⡣⡑⢔⠸⣞⣽⢜⡮⣟⢞⠰⡑⢌⡯⡮⡣⡇⣇⢥⣑⡕⣍⠪⠢⡡⠱⡨⡊⡢⡑⠕⢔⠱⡨⢪⢪⢪⢪⡪⡺⡸⡜⡜⣎⢞⡮⡷⡽⣝⢮⢟⡮⣺⡺⡵⣳⢽⢽⢽⢵⢯⢿⣝⡮⣗⡽⡽⣵⣻
⢜⢜⢼⢸⢸⡰⡱⡕⣎⢮⡢⡱⡑⡕⢕⠕⡥⡳⡕⢕⠕⣕⢇⢇⡇⢜⢵⢝⢮⢑⢜⠰⠨⠢⡑⢝⣯⡿⢝⢌⠢⡑⢌⣞⣝⢎⠧⡫⡞⢔⢸⡫⡌⢣⠣⡊⡪⠢⡑⢌⢜⢘⢌⢪⢸⢸⢸⢸⢸⢸⢪⢪⢎⢧⢳⢍⢯⢯⣻⣺⢵⢯⣻⡪⣞⡽⣳⢽⢯⢯⣫⢯⣟⣞⢾⢵⣫⢯⢾⣺
⡪⡳⡝⣎⣗⢝⢮⢫⡪⡎⣞⢕⢧⢣⠣⡝⡎⡧⡣⡑⢈⢎⢎⢞⢜⠜⡜⡵⡫⡬⡢⣑⣅⡃⡊⡂⡂⡊⢆⠢⡑⣌⡾⡜⡮⡳⡱⡑⢌⠢⡱⣫⢆⠑⢅⠪⡨⠪⡨⠢⡑⢌⠢⡱⡱⡱⡕⡕⣕⢵⢱⡣⡳⡕⣗⢝⡎⡟⡾⡽⡽⡽⣎⢯⣺⢽⡵⣟⣽⢯⢞⣗⣷⣫⢯⢷⢽⢽⢽⣺
⡪⡫⡮⡳⣕⡏⣗⢵⢕⣝⢜⢮⡫⣳⢕⡇⡯⡺⡪⡪⡪⡪⡪⡪⡪⡪⡪⣞⢕⢕⢇⡇⡇⡯⡳⣳⣲⣔⢄⢂⠌⣺⢮⠳⡑⢅⠅⡌⡐⡨⣺⣵⢧⢅⠀⠳⡨⠪⡨⠪⡨⠢⡑⡕⡕⡵⡹⡜⣎⢮⡣⣫⢪⡳⣕⢗⡝⣎⢯⢯⢯⣻⣪⢟⣞⢷⢽⢽⣺⢯⣻⣺⣺⢾⢽⢽⢽⢽⢽⣺
⡪⣳⢝⣝⢮⡺⡵⣝⢮⣪⡳⣳⡹⣪⡳⣝⢼⡪⡳⡳⣕⢵⢱⡱⡱⡱⣱⡣⡇⡇⢇⢎⢪⢪⢺⢸⢜⢮⣻⢦⢣⡳⡲⣝⢮⣳⣽⣭⢯⣺⢽⢝⣷⡹⣲⢤⣁⠣⠨⠪⠨⠨⡸⡸⡸⣪⡣⣏⢞⡼⡪⡪⡧⣫⢮⢺⡪⡺⡪⡯⣻⢺⡺⣝⢾⢽⢝⡽⣞⣟⣞⣞⣞⣯⢟⡽⡽⣽⢽⣺
⡪⣗⣝⢮⡳⣝⣞⢮⡳⡵⣝⢮⡺⡵⣝⢮⡳⣹⢜⢽⡸⣪⢗⢵⣫⢪⢲⢕⢯⢪⠪⡪⡪⡪⡪⡪⣪⢳⢕⣗⢷⢝⢮⢪⢮⣺⡺⣪⢫⢝⢜⢝⢮⡻⣞⢷⠽⡵⣕⢬⢦⢧⢶⢜⣬⡪⣪⢞⡵⡳⡹⡘⣝⢮⢪⡣⡫⣎⢗⣝⢮⢣⢏⢾⢝⣗⡯⣟⡾⣺⣺⣺⣺⢽⡽⣽⣫⡯⣟⡾
⢝⡞⡮⣳⢽⡺⣜⢗⡽⣝⣞⢽⢺⢝⡮⣳⢝⡮⣳⡣⡯⣪⢯⡳⣕⢗⢝⡽⡸⡰⡱⡑⡕⡜⢜⢜⡼⣽⣽⢽⢽⣕⡯⣯⣻⠪⠹⣎⢧⡳⣕⢽⠱⡯⣎⢧⡫⣎⢷⡝⡽⡽⡝⡝⣜⢮⢳⡳⡝⣜⢎⢆⠑⡝⡮⣪⡳⡱⡱⡪⡪⣊⢊⢈⠑⠧⡯⣳⣻⣳⣳⡳⣯⣻⡽⣳⣳⢯⡷⣻
⢳⡹⣝⢮⡳⣝⡮⡯⣺⡪⣞⢎⣗⣝⢮⡳⣫⢞⣕⢗⡽⣜⡵⣝⢮⡳⡝⣎⢎⢎⢪⠪⡪⡪⣮⢿⣽⣷⣟⣯⡿⣞⣯⡷⣇⡯⣪⡘⣳⡽⣮⡳⢁⢊⡯⣷⣝⣞⢮⣻⣪⢪⢪⣪⢺⡪⣳⡹⣪⢺⡸⡪⡂⡈⠺⢸⠘⠌⢌⢂⢇⢧⠱⡐⡠⢈⠺⡜⡮⣺⢮⢯⣗⣷⣻⢽⣞⡯⣯⢿
⢕⡝⡮⡳⡽⣕⢯⢞⣗⣝⢮⡳⣕⢧⡳⣝⢮⡳⡳⣝⢮⡺⣺⣪⡳⣝⢞⣾⢯⢣⣣⣳⡽⣽⣯⣿⣿⢷⣻⣷⡿⣫⢯⡻⡶⡟⡆⢇⠂⢫⢿⡧⣳⣝⡾⣮⣿⣾⣻⣎⢷⢝⢮⡪⡧⡫⡮⡺⣜⢵⢝⢵⢱⠠⡂⡐⠌⡊⢆⠅⢯⢎⢗⢕⢌⢆⢂⠱⡹⣪⢯⣗⡷⣳⡯⣟⡾⣽⢽⣽
⡪⡮⡳⣕⣝⢮⣫⡳⣕⢗⣗⢽⣪⢗⡽⡮⣳⢽⣹⡪⣗⢽⡺⣜⢾⢕⣯⣺⡽⣗⣿⣺⣟⣿⣽⣿⣯⣿⣿⣿⣟⢌⠌⡊⡘⢈⠃⠡⢈⠠⠑⣟⠺⡽⣝⢾⣻⣿⣿⡾⣝⣯⢺⡪⣳⢹⡪⣺⣪⢳⢝⣕⢇⢇⢢⢂⠁⠄⠠⢈⠘⣎⢧⢣⢣⢕⢌⡂⢝⢮⣳⣳⣻⣳⣻⣳⣻⢽⢽⣺
⢮⢎⢯⢎⡞⣜⢖⣝⢮⡳⣕⢯⢮⢯⢞⡽⣪⢷⢕⡯⣺⢵⡫⣞⢵⣫⢞⡼⡝⡝⢯⢻⡛⡏⢯⡷⣿⣻⣿⣽⣿⣎⢆⢆⢂⠢⡈⠄⠧⡢⢁⠄⠅⡊⠌⢕⣿⡿⣾⣿⣟⡾⣕⢕⢧⢳⡹⡜⣎⢗⡝⣎⢯⢺⡸⡰⡡⢅⢅⠂⢄⠸⣪⡫⡎⡎⡆⡕⡐⣕⢗⣗⣯⢾⡽⣞⡽⡽⡽⣮
⡸⡵⡝⡮⣺⢸⢕⡕⡧⣫⢞⣝⢮⣳⣫⢾⣹⢵⡫⣞⡵⣫⢞⡵⣝⢮⡳⣝⢎⢪⠪⡢⡣⡣⣻⣟⣿⣿⣻⣿⣻⣿⣷⣵⢥⢅⠍⠭⡓⡮⠲⡈⢆⢪⣪⣾⣿⣟⣿⣻⣯⣿⡽⣞⢜⢎⢮⢺⡸⡱⡹⡸⡸⡱⡱⡱⡱⡱⡡⡑⠀⠂⣇⢯⡪⡪⡪⡪⡂⡪⡯⣞⣞⣯⢟⣷⢽⢽⣽⣻
⢮⡳⣝⡞⡮⡳⣕⢝⢮⢎⡗⡵⣫⡺⡼⣕⣗⢗⣝⢮⢯⢎⢇⢏⢎⢇⢯⢎⢪⢢⠣⡣⡱⡱⣿⣻⣽⣾⣿⣻⣟⣯⣿⣿⣟⡷⣽⣰⢰⣸⣼⣮⣷⣿⣿⣿⣟⣯⣿⣽⡿⣷⣻⡯⡳⣹⢸⢱⢱⢱⢑⠕⢜⠌⡌⡪⡈⡂⠢⢨⢠⢪⢸⣪⢺⢜⢜⢔⢕⠌⡯⣻⡺⡽⣝⣗⣟⣽⣺⣺
⣳⣫⡳⣝⣞⣯⡿⣽⣯⢷⡿⣽⣗⣯⣿⣺⣞⣿⣺⣽⢷⣻⣽⢷⣱⢱⢱⢇⢣⢱⠱⡑⡕⣽⣟⣿⣻⣿⣽⣿⣿⢿⠟⡗⡵⣍⢕⢳⢯⣳⢽⢯⢿⣻⣿⣟⣿⣿⣟⣷⣏⡧⣗⡵⣹⢜⡜⣜⡼⡼⣜⣝⣜⢕⢇⢇⢧⡳⣫⢳⡹⡜⣜⢎⣗⢽⡱⡳⣱⢵⣻⣺⡮⡯⣷⣻⣞⣷⣻⣾
⡿⣮⡫⣞⣝⣽⣿⣻⣾⢿⣻⣫⢫⢻⢺⢻⣽⡷⣟⣿⣻⢿⡽⡹⡸⡸⡸⡕⡱⡑⢕⠱⣸⢷⣟⣯⡿⣷⢿⢳⡹⣪⢯⣪⢺⡸⣹⢨⣳⠨⡯⡳⡵⣗⣝⢿⣯⣿⣿⣽⣾⣻⣽⡽⣽⣝⢮⣗⣯⣟⣗⣟⣞⢯⢯⢯⣳⢽⣪⣗⣽⡺⣮⣳⢳⡳⣕⣝⢵⣫⢟⣾⡻⣪⡺⣜⣯⣯⢷⡷
⣯⣗⣽⣺⢾⣽⢾⣻⡺⣵⡳⣕⡯⡮⣇⢗⣝⡿⣯⡷⣟⣯⡇⡇⡇⡇⡇⡇⢇⣎⢎⣪⢾⣻⣽⢯⡫⡮⢪⡺⣽⣺⣻⣝⢧⢹⡪⣇⢷⢭⢯⡇⡯⣗⢯⢶⡱⠽⣾⢿⡾⣞⣮⢮⡪⣪⣳⣳⢳⡳⡲⡲⡸⡨⡳⣕⢧⣫⢳⢝⡞⣝⢮⢮⡳⣽⣺⡺⣽⡺⣽⢽⢽⢮⡺⡮⡷⡯⡿⣝
⣷⣳⣯⢿⡽⣯⣟⣷⢽⣾⣺⢷⡽⣽⣺⣳⡵⣟⣷⣟⣯⡷⣟⢜⢜⢜⢜⢜⢔⢺⢽⣞⡏⢝⠚⣕⢝⣜⡵⣟⣾⣯⣷⣯⣗⢵⢝⢮⣺⣝⢽⡺⣜⣯⢯⣳⡻⡝⡎⡎⣍⣟⣞⣟⡾⣵⣳⢽⣳⣫⣽⡺⡝⣜⢜⣮⣳⣳⣝⣗⣟⡮⣗⣯⣞⣗⡷⣽⡳⡯⣷⣻⢽⣻⣞⡿⣝⣯⢯⣗
⡷⣟⡾⣯⣟⣷⣻⢾⣻⡾⣽⡯⣿⡽⣾⢷⣻⣟⣾⣳⡯⣿⢽⣽⣺⣼⢾⡮⣮⣎⢎⠪⡙⡰⡨⢨⠹⣺⣻⣽⡿⣾⣻⣺⣪⢪⡯⣟⡎⣷⢱⣻⣪⢿⣟⣗⡕⡌⣮⢞⢔⡪⡷⡯⣻⣞⢾⢽⣺⣺⢶⣜⣜⣎⣞⣾⣺⣞⣾⣺⢾⢽⡽⣞⣞⣗⣯⢷⣻⣽⣳⢯⡯⣗⡯⣟⣽⢽⣫⢷
⢽⢯⣟⣷⣻⢾⡽⣿⢽⣯⢷⣟⣯⡿⣽⢯⣷⣻⣞⣷⣻⢯⣟⣷⣻⣞⡯⣟⣗⣯⢸⢺⢪⣢⣫⣾⣜⢮⢞⣗⣯⣳⣳⣳⢯⢷⣟⣗⣇⢿⡸⣺⣳⢫⣿⣞⡾⣽⣟⣯⢿⢞⡮⣯⢷⢯⢿⢽⣳⢯⣷⣳⣟⣮⢷⣳⣗⣷⣳⢯⡿⣽⡽⣽⢞⣗⡯⣟⣗⡷⣯⢿⡽⣽⢽⣳⢯⣻⣺⣻
⡻⡝⣾⡺⡽⣯⢿⣽⣻⢾⣻⣽⢾⡯⣿⡽⣾⣳⣟⣾⡽⣯⣷⣻⢾⣺⡯⣟⡾⡽⣽⢽⣳⢯⣻⣽⢿⡽⣽⣺⣺⣺⣺⡾⣫⡇⢷⢕⡷⡱⣯⡚⣞⡮⣫⣷⣿⣿⣻⣾⣻⢿⢽⡽⡽⡯⡿⣽⢽⣽⣺⣞⣾⣺⢯⣗⣟⢾⣝⡯⡯⣗⣯⢯⢏⢮⢝⣗⣯⣻⣞⡯⣯⢯⡻⡮⡣⠡⡣⡳
⣝⢎⢖⢽⣫⢯⣟⡾⣽⢯⣿⣺⢿⡽⣗⡏⣧⣻⣞⣷⣻⢗⣟⣾⣻⣳⣟⢿⢽⢯⡷⣻⣺⢽⣺⣺⣻⣽⣳⣻⣞⣾⡯⡿⡽⡼⣹⡕⣏⢗⢵⣳⢱⣫⢗⡽⣹⣟⡾⣳⢽⢯⣗⡯⣟⡽⡽⡾⣽⣺⣺⣺⣺⡺⣽⣺⣺⡳⣳⢯⢯⣗⡯⣟⢮⣳⢽⣺⣞⣞⣞⢾⢵⡫⡯⡺⣜⣕⢕⣝
⣪⢷⢽⣕⢷⣝⣞⡽⣽⢽⣞⡾⡯⡯⣷⣻⣳⣗⣯⢾⣺⢯⣟⣞⡾⡵⡯⡯⣯⣻⡺⡯⣯⡻⡮⣷⢯⢿⡿⣽⣾⢷⣻⡣⡋⡻⣺⣪⢯⢇⡇⣟⣎⢎⢧⢫⢮⣾⣽⢾⣯⣳⣳⢽⢵⢯⢯⣻⡺⣺⡪⣞⢮⣻⡪⣞⢮⢞⣗⢯⣳⡳⡽⣝⢽⣺⣫⡳⣻⢺⣓⢏⢟⢞⡽⣝⢮⢾⢵⣝
⢯⢯⣗⠯⣷⣳⣳⢿⡽⣯⢾⡽⣽⣫⣗⢷⣳⣳⢽⢽⣺⢽⡺⡮⡯⡯⣯⣻⡺⡮⡯⡯⣺⢽⢝⡾⣝⢗⢯⣳⡫⡿⣷⣷⡮⣜⡔⣎⢎⢇⢧⢣⡿⡮⣮⢯⣟⣾⣺⣝⡮⡺⣜⣝⢭⡳⣛⡞⡮⡳⣝⢮⡳⡵⣝⢮⣫⡳⡳⣝⢮⢮⡳⡽⣕⣗⢗⡽⣳⢽⡺⡽⡽⡽⣹⢝⣞⢽⡳⡵
⣫⢯⢆⡇⣗⢟⡞⡽⣝⡽⣳⢝⣞⢮⡺⣝⢮⡺⡽⣝⢾⢽⢝⡽⣝⢽⡪⣞⢮⣻⡪⡯⣞⣵⣻⡺⡮⣯⣗⣗⡯⣟⣷⢯⣯⢾⡮⣷⡽⣽⢽⣿⣽⡾⣯⡿⣽⣞⣷⢯⡿⣝⡮⣮⣳⣝⣞⢮⡫⡯⣺⢵⢝⣞⢮⡳⡵⣝⣝⢮⡳⣝⡮⡯⣺⣪⢯⣻⡺⣽⡺⡽⣺⢽⢕⣟⢮⢧⢹⡺
⡕⡧⡳⡹⣜⢵⢝⢮⡺⡼⣕⢯⢞⢵⢻⡪⣗⢯⡫⣞⢽⢹⡹⣪⢳⢝⢮⢳⢳⢕⢽⡹⣪⢺⢜⢮⢯⡺⣪⢯⡿⣯⢿⡽⣾⣻⡽⣷⣻⢯⡿⣷⣟⡿⣯⢿⣽⣞⣯⣟⣟⣯⣟⣷⣳⢻⡺⣕⢯⢫⢮⡳⣝⣮⡺⣪⣳⡣⣗⡽⣺⢕⡷⣝⣞⢮⣳⡳⡽⡮⡯⡯⣳⢯⢕⢕⡙⡎⡎⠮
⢯⡪⣳⢹⢜⢎⢗⢝⢜⢕⠵⡕⣝⢭⢣⢫⢪⢪⡪⡎⡎⡇⡏⡎⡇⡗⡝⡜⡕⡝⡜⡜⡜⡜⢎⢇⢏⢎⢏⢽⣽⣯⣷⣻⢞⣾⣺⣳⢯⢿⢽⢯⣿⣻⣽⣟⣷⣿⡪⡣⡫⡪⡪⡺⡸⡹⡪⣳⢹⡹⡕⡏⣖⠷⢽⢕⢷⢝⣗⢯⢷⡻⣞⢾⡪⡷⡵⡝⣞⡺⣪⡫⡮⡫⣫⢣⢝⢼⢬⢣
⡎⡞⡜⡜⡜⡎⡮⡪⡪⡣⡫⡪⡒⡕⡕⡕⡕⡕⡜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢌⢎⢜⢜⢜⢜⢜⢜⢜⢻⢻⢺⢳⢣⢣⢣⢪⢪⢣⢫⢣⢫⢪⢍⢏⢝⢝⢜⢎⢎⢎⢎⢎⢎⢎⢎⢮⢪⡣⡳⡱⡱⡱⡩⡣⡣⡳⡱⡪⡎⣇⢧⢳⢱⡹⣸⡪⡺⣪⢺⢪⢺⡸⡱⣕⢝⡜⣕⢝⡎
⢣⢣⢣⠫⡪⡚⡜⡪⢪⠪⡪⢪⢚⢪⠪⡚⡜⢜⢸⢘⢔⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⡱⡑⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡝⡜⡕⣕⢕⢕⢕⢕⢝⢼⢸⢸⢸⢸⢸⢸⢱⢱⡱⡱⡱⡱⡹⡸⡪⡣⡳⡱⡹⡸⡸⡸⡸⡜⣎⢮⢣⡳

        
⠡⡡⢡⠑⢅⠣⡑⢕⠱⡱⡩⡪⡪⡱⡱⡩⡪⡪⣱⢕⢍⢎⢎⢎⢎⠪⡊⢎⠪⣊⠪⣊⠪⡊⡪⡊⡪⡊⢎⢊⠪⡊⢎⠪⠪⡪⡊⢎⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡫⡝⡭⣫⢯⠯⡯⣏⢯⣫⣫⣝⣝⢽⢽⢝⡽⢭⡫⣫⡫⡳⣹⢹⣹⡹⡭⡫⣝⢵
⢂⢊⠢⠡⡡⡑⢌⠢⡑⢌⠪⡪⢪⠪⡪⢪⠪⡪⡪⣷⢑⢕⠕⡕⢕⢕⢱⢑⢕⢢⠣⡢⣃⢇⢪⠨⠢⡊⡢⡑⡑⢌⠢⡑⡑⢌⢌⠢⡑⢌⠢⡣⠱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡡⡃⢎⠢⡃⡇⣏⢮⢗⣯⢯⡺⡪⣇⢗⢮⣞⢮⣗⢯⣳⡫⣗⢽⡪⡮⡳⣕⢽⢜⢮⡪⣇⢗⢵
⢂⠢⠡⡑⡐⠨⡐⡑⢌⠢⡑⢜⠸⡘⡜⢌⢎⢪⠪⣟⣎⢆⢇⢣⢣⠱⡡⡣⡑⡅⢇⢪⡞⢌⠢⡑⢅⢕⢐⠕⢌⠢⡑⢌⢌⠢⠢⡑⢌⠢⡑⠜⡌⡪⡘⡌⢎⢜⢌⢎⢜⢌⢎⠜⡔⡑⡌⡪⡘⡌⡪⣪⢏⢮⢯⣗⡯⣳⢵⢝⣞⢮⣗⢽⢕⣗⢽⣪⡳⡝⡮⡺⣜⢮⢳⡣⡳⣕⣝⢵
⢐⠨⢂⠢⡈⡂⡢⠨⡂⢕⠨⠢⡑⡑⢌⠢⡑⢕⠱⡽⡵⡕⡅⢇⢪⠪⡢⡑⢕⢘⢬⡟⢌⠢⡑⢌⠢⠢⢡⠡⡡⡑⢌⢂⠢⠡⡑⢌⠢⡑⢌⢊⠢⡑⢌⠪⡘⢔⠱⡨⢢⠣⡊⡎⢜⢌⠆⡕⢌⢪⢸⢸⢝⢎⢧⡳⡯⡯⣫⢗⣗⢯⢮⣫⡳⣕⢗⣕⢧⢫⡺⣪⡺⣪⡣⡏⣞⢎⢮⡺
⠐⠨⢐⢐⢐⠐⢌⠐⢌⠐⢅⢑⠐⢌⠢⡑⠌⡌⡊⡾⡯⣗⠜⡌⢆⢣⠪⡨⠢⣱⡟⢌⠂⢕⠨⡂⠅⠕⢅⢑⢐⢌⢂⢢⣡⣕⣎⢦⢇⢮⠢⠡⡃⡪⠢⡑⢌⠢⡑⢌⠢⠣⡑⢜⠌⢆⢕⠸⡨⢢⢣⢳⡹⡕⣇⢏⡯⡯⡯⣳⢯⣫⢺⢜⢮⡳⣝⣜⢮⢣⡳⣕⢝⢖⢵⡹⣪⡫⣇⢯
⠨⢈⢐⠐⡐⠨⠠⠑⢄⢑⠐⠄⠅⢅⠑⠌⢌⢂⠢⣻⣝⡿⡌⠌⢌⠢⡣⢱⣹⣗⢃⠢⡑⠄⢕⠨⠨⡊⠢⡑⡐⢔⢰⣳⢷⣕⣗⡝⡵⡕⢯⠨⡂⡪⠨⡊⡢⡑⢌⠢⡑⡑⢌⠢⡑⡑⡌⡪⡘⢜⢜⡕⡧⣫⢪⢮⢺⣫⢯⣏⡗⣎⢗⣝⢕⢧⡳⡪⡮⣣⢳⢕⡽⡕⡧⡫⡮⡺⣜⢮
⢐⠐⡐⢐⠠⠡⠈⠌⡐⠠⢁⠅⠅⡂⠅⡑⢐⠠⠡⣗⢷⣝⡧⠡⠡⡱⡘⣼⣳⢗⡅⢕⠨⡈⠢⠡⡑⠌⢌⢂⢊⢢⣟⣞⣿⣳⢵⢝⠼⡕⣝⡕⢌⢌⢊⠢⡂⡪⠢⡑⢌⢌⠢⡑⢌⠢⡊⢆⠕⡕⣇⢯⢺⢜⢕⡕⡧⣫⣗⢷⡹⣜⢵⡱⣝⢵⡹⣪⡺⣪⢣⡳⡵⡝⣎⢗⣝⢮⣗⢯
⠄⡂⢂⠂⠌⡐⠡⢁⠂⠅⡂⠌⡐⠠⢡⠂⠅⡊⠢⠩⡳⣳⢽⡘⢌⢢⣺⢽⢊⢏⢯⡢⢑⠌⢌⢂⠪⡨⡂⢆⢱⣝⢾⢿⣾⢯⣻⡪⡝⣞⢢⡗⡕⡐⡅⠕⢌⢌⠪⡨⡂⠆⢕⢌⠢⡃⢎⠢⡣⡱⡕⡧⡳⡹⡜⣎⢞⣺⡺⣽⡺⡪⣎⢞⡜⡮⣺⡪⡺⣜⢵⡹⣪⡺⣜⣗⡽⣕⡯⣏
⢐⢐⢐⠨⢐⠠⡁⠢⠨⢐⠠⡁⡂⢅⠢⠹⢦⡨⡈⠢⢑⢕⢗⠕⢠⢳⢙⢐⢐⡸⣕⢯⠐⠌⡂⡢⡑⡐⢌⢢⣳⣯⣯⣟⢝⢔⡷⡕⣝⢼⢘⢎⢎⢪⠨⡊⢆⢢⠱⡰⡘⢌⠆⢆⠣⡪⡘⡌⢆⢇⢗⢵⢹⢪⢺⢸⢪⡺⣺⢵⢯⡣⡳⣕⢝⢮⡳⣝⢝⢮⡻⣺⣳⢯⢗⣗⡽⡮⣻⣪
⡰⡐⡆⢎⠢⡣⡢⡣⡱⡨⡒⡌⢎⢎⠪⡪⡪⡹⣺⢬⢠⢀⡱⣕⢮⢂⢰⢰⢫⢸⢸⢪⢈⢂⢂⢂⡂⠪⡐⣼⢮⣳⡟⡊⡂⣳⣝⢮⢪⠇⢝⡗⢕⣅⢣⢑⠕⡌⡪⢢⢑⢅⠣⡑⢕⠌⡆⢕⢕⢕⢇⢗⢝⡜⣕⢝⡜⡮⡯⡯⡷⡝⣎⢮⡫⣮⣻⣺⢝⣗⡽⣳⢽⢯⢯⡺⣺⢝⡮⣞
⠪⡘⡸⡰⡑⢌⢆⢣⢊⢆⢇⢇⢇⢇⢣⢱⢑⠕⣜⠜⢑⠑⢜⡎⠯⠊⡂⢎⡮⡺⡸⡸⢐⢐⢰⡳⡅⣱⣸⡫⣷⢗⠱⡨⢪⣞⢼⢸⡸⡎⢦⡪⡂⡇⢆⢕⢑⢌⠪⡢⡑⢌⢪⢘⢔⠱⡘⡜⡜⡎⡇⡏⣎⢮⢪⡺⣸⢝⡾⡽⣹⢽⡸⣕⡽⣺⣺⣺⢽⢮⢫⡯⡿⡽⣕⢯⡳⡽⣺⢵
⡡⡱⡱⡘⢜⢌⢆⢇⢎⢎⢆⢕⢕⢕⢱⢸⢨⢪⢱⡑⡆⠌⡜⢌⢂⢕⢆⠅⡕⡯⡣⡣⡑⢔⠸⣞⣽⢜⡮⣟⢞⠰⡑⢌⡯⡮⡣⡇⣇⢥⣑⡕⣍⠪⠢⡡⠱⡨⡊⡢⡑⠕⢔⠱⡨⢪⢪⢪⢪⡪⡺⡸⡜⡜⣎⢞⡮⡷⡽⣝⢮⢟⡮⣺⡺⡵⣳⢽⢽⢽⢵⢯⢿⣝⡮⣗⡽⡽⣵⣻
⢜⢜⢼⢸⢸⡰⡱⡕⣎⢮⡢⡱⡑⡕⢕⠕⡥⡳⡕⢕⠕⣕⢇⢇⡇⢜⢵⢝⢮⢑⢜⠰⠨⠢⡑⢝⣯⡿⢝⢌⠢⡑⢌⣞⣝⢎⠧⡫⡞⢔⢸⡫⡌⢣⠣⡊⡪⠢⡑⢌⢜⢘⢌⢪⢸⢸⢸⢸⢸⢸⢪⢪⢎⢧⢳⢍⢯⢯⣻⣺⢵⢯⣻⡪⣞⡽⣳⢽⢯⢯⣫⢯⣟⣞⢾⢵⣫⢯⢾⣺
⡪⡳⡝⣎⣗⢝⢮⢫⡪⡎⣞⢕⢧⢣⠣⡝⡎⡧⡣⡑⢈⢎⢎⢞⢜⠜⡜⡵⡫⡬⡢⣑⣅⡃⡊⡂⡂⡊⢆⠢⡑⣌⡾⡜⡮⡳⡱⡑⢌⠢⡱⣫⢆⠑⢅⠪⡨⠪⡨⠢⡑⢌⠢⡱⡱⡱⡕⡕⣕⢵⢱⡣⡳⡕⣗⢝⡎⡟⡾⡽⡽⡽⣎⢯⣺⢽⡵⣟⣽⢯⢞⣗⣷⣫⢯⢷⢽⢽⢽⣺
⡪⡫⡮⡳⣕⡏⣗⢵⢕⣝⢜⢮⡫⣳⢕⡇⡯⡺⡪⡪⡪⡪⡪⡪⡪⡪⡪⣞⢕⢕⢇⡇⡇⡯⡳⣳⣲⣔⢄⢂⠌⣺⢮⠳⡑⢅⠅⡌⡐⡨⣺⣵⢧⢅⠀⠳⡨⠪⡨⠪⡨⠢⡑⡕⡕⡵⡹⡜⣎⢮⡣⣫⢪⡳⣕⢗⡝⣎⢯⢯⢯⣻⣪⢟⣞⢷⢽⢽⣺⢯⣻⣺⣺⢾⢽⢽⢽⢽⢽⣺
⡪⣳⢝⣝⢮⡺⡵⣝⢮⣪⡳⣳⡹⣪⡳⣝⢼⡪⡳⡳⣕⢵⢱⡱⡱⡱⣱⡣⡇⡇⢇⢎⢪⢪⢺⢸⢜⢮⣻⢦⢣⡳⡲⣝⢮⣳⣽⣭⢯⣺⢽⢝⣷⡹⣲⢤⣁⠣⠨⠪⠨⠨⡸⡸⡸⣪⡣⣏⢞⡼⡪⡪⡧⣫⢮⢺⡪⡺⡪⡯⣻⢺⡺⣝⢾⢽⢝⡽⣞⣟⣞⣞⣞⣯⢟⡽⡽⣽⢽⣺
⡪⣗⣝⢮⡳⣝⣞⢮⡳⡵⣝⢮⡺⡵⣝⢮⡳⣹⢜⢽⡸⣪⢗⢵⣫⢪⢲⢕⢯⢪⠪⡪⡪⡪⡪⡪⣪⢳⢕⣗⢷⢝⢮⢪⢮⣺⡺⣪⢫⢝⢜⢝⢮⡻⣞⢷⠽⡵⣕⢬⢦⢧⢶⢜⣬⡪⣪⢞⡵⡳⡹⡘⣝⢮⢪⡣⡫⣎⢗⣝⢮⢣⢏⢾⢝⣗⡯⣟⡾⣺⣺⣺⣺⢽⡽⣽⣫⡯⣟⡾
⢝⡞⡮⣳⢽⡺⣜⢗⡽⣝⣞⢽⢺⢝⡮⣳⢝⡮⣳⡣⡯⣪⢯⡳⣕⢗⢝⡽⡸⡰⡱⡑⡕⡜⢜⢜⡼⣽⣽⢽⢽⣕⡯⣯⣻⠪⠹⣎⢧⡳⣕⢽⠱⡯⣎⢧⡫⣎⢷⡝⡽⡽⡝⡝⣜⢮⢳⡳⡝⣜⢎⢆⠑⡝⡮⣪⡳⡱⡱⡪⡪⣊⢊⢈⠑⠧⡯⣳⣻⣳⣳⡳⣯⣻⡽⣳⣳⢯⡷⣻
⢳⡹⣝⢮⡳⣝⡮⡯⣺⡪⣞⢎⣗⣝⢮⡳⣫⢞⣕⢗⡽⣜⡵⣝⢮⡳⡝⣎⢎⢎⢪⠪⡪⡪⣮⢿⣽⣷⣟⣯⡿⣞⣯⡷⣇⡯⣪⡘⣳⡽⣮⡳⢁⢊⡯⣷⣝⣞⢮⣻⣪⢪⢪⣪⢺⡪⣳⡹⣪⢺⡸⡪⡂⡈⠺⢸⠘⠌⢌⢂⢇⢧⠱⡐⡠⢈⠺⡜⡮⣺⢮⢯⣗⣷⣻⢽⣞⡯⣯⢿
⢕⡝⡮⡳⡽⣕⢯⢞⣗⣝⢮⡳⣕⢧⡳⣝⢮⡳⡳⣝⢮⡺⣺⣪⡳⣝⢞⣾⢯⢣⣣⣳⡽⣽⣯⣿⣿⢷⣻⣷⡿⣫⢯⡻⡶⡟⡆⢇⠂⢫⢿⡧⣳⣝⡾⣮⣿⣾⣻⣎⢷⢝⢮⡪⡧⡫⡮⡺⣜⢵⢝⢵⢱⠠⡂⡐⠌⡊⢆⠅⢯⢎⢗⢕⢌⢆⢂⠱⡹⣪⢯⣗⡷⣳⡯⣟⡾⣽⢽⣽
⡪⡮⡳⣕⣝⢮⣫⡳⣕⢗⣗⢽⣪⢗⡽⡮⣳⢽⣹⡪⣗⢽⡺⣜⢾⢕⣯⣺⡽⣗⣿⣺⣟⣿⣽⣿⣯⣿⣿⣿⣟⢌⠌⡊⡘⢈⠃⠡⢈⠠⠑⣟⠺⡽⣝⢾⣻⣿⣿⡾⣝⣯⢺⡪⣳⢹⡪⣺⣪⢳⢝⣕⢇⢇⢢⢂⠁⠄⠠⢈⠘⣎⢧⢣⢣⢕⢌⡂⢝⢮⣳⣳⣻⣳⣻⣳⣻⢽⢽⣺
⢮⢎⢯⢎⡞⣜⢖⣝⢮⡳⣕⢯⢮⢯⢞⡽⣪⢷⢕⡯⣺⢵⡫⣞⢵⣫⢞⡼⡝⡝⢯⢻⡛⡏⢯⡷⣿⣻⣿⣽⣿⣎⢆⢆⢂⠢⡈⠄⠧⡢⢁⠄⠅⡊⠌⢕⣿⡿⣾⣿⣟⡾⣕⢕⢧⢳⡹⡜⣎⢗⡝⣎⢯⢺⡸⡰⡡⢅⢅⠂⢄⠸⣪⡫⡎⡎⡆⡕⡐⣕⢗⣗⣯⢾⡽⣞⡽⡽⡽⣮
⡸⡵⡝⡮⣺⢸⢕⡕⡧⣫⢞⣝⢮⣳⣫⢾⣹⢵⡫⣞⡵⣫⢞⡵⣝⢮⡳⣝⢎⢪⠪⡢⡣⡣⣻⣟⣿⣿⣻⣿⣻⣿⣷⣵⢥⢅⠍⠭⡓⡮⠲⡈⢆⢪⣪⣾⣿⣟⣿⣻⣯⣿⡽⣞⢜⢎⢮⢺⡸⡱⡹⡸⡸⡱⡱⡱⡱⡱⡡⡑⠀⠂⣇⢯⡪⡪⡪⡪⡂⡪⡯⣞⣞⣯⢟⣷⢽⢽⣽⣻
⢮⡳⣝⡞⡮⡳⣕⢝⢮⢎⡗⡵⣫⡺⡼⣕⣗⢗⣝⢮⢯⢎⢇⢏⢎⢇⢯⢎⢪⢢⠣⡣⡱⡱⣿⣻⣽⣾⣿⣻⣟⣯⣿⣿⣟⡷⣽⣰⢰⣸⣼⣮⣷⣿⣿⣿⣟⣯⣿⣽⡿⣷⣻⡯⡳⣹⢸⢱⢱⢱⢑⠕⢜⠌⡌⡪⡈⡂⠢⢨⢠⢪⢸⣪⢺⢜⢜⢔⢕⠌⡯⣻⡺⡽⣝⣗⣟⣽⣺⣺
⣳⣫⡳⣝⣞⣯⡿⣽⣯⢷⡿⣽⣗⣯⣿⣺⣞⣿⣺⣽⢷⣻⣽⢷⣱⢱⢱⢇⢣⢱⠱⡑⡕⣽⣟⣿⣻⣿⣽⣿⣿⢿⠟⡗⡵⣍⢕⢳⢯⣳⢽⢯⢿⣻⣿⣟⣿⣿⣟⣷⣏⡧⣗⡵⣹⢜⡜⣜⡼⡼⣜⣝⣜⢕⢇⢇⢧⡳⣫⢳⡹⡜⣜⢎⣗⢽⡱⡳⣱⢵⣻⣺⡮⡯⣷⣻⣞⣷⣻⣾
⡿⣮⡫⣞⣝⣽⣿⣻⣾⢿⣻⣫⢫⢻⢺⢻⣽⡷⣟⣿⣻⢿⡽⡹⡸⡸⡸⡕⡱⡑⢕⠱⣸⢷⣟⣯⡿⣷⢿⢳⡹⣪⢯⣪⢺⡸⣹⢨⣳⠨⡯⡳⡵⣗⣝⢿⣯⣿⣿⣽⣾⣻⣽⡽⣽⣝⢮⣗⣯⣟⣗⣟⣞⢯⢯⢯⣳⢽⣪⣗⣽⡺⣮⣳⢳⡳⣕⣝⢵⣫⢟⣾⡻⣪⡺⣜⣯⣯⢷⡷
⣯⣗⣽⣺⢾⣽⢾⣻⡺⣵⡳⣕⡯⡮⣇⢗⣝⡿⣯⡷⣟⣯⡇⡇⡇⡇⡇⡇⢇⣎⢎⣪⢾⣻⣽⢯⡫⡮⢪⡺⣽⣺⣻⣝⢧⢹⡪⣇⢷⢭⢯⡇⡯⣗⢯⢶⡱⠽⣾⢿⡾⣞⣮⢮⡪⣪⣳⣳⢳⡳⡲⡲⡸⡨⡳⣕⢧⣫⢳⢝⡞⣝⢮⢮⡳⣽⣺⡺⣽⡺⣽⢽⢽⢮⡺⡮⡷⡯⡿⣝
⣷⣳⣯⢿⡽⣯⣟⣷⢽⣾⣺⢷⡽⣽⣺⣳⡵⣟⣷⣟⣯⡷⣟⢜⢜⢜⢜⢜⢔⢺⢽⣞⡏⢝⠚⣕⢝⣜⡵⣟⣾⣯⣷⣯⣗⢵⢝⢮⣺⣝⢽⡺⣜⣯⢯⣳⡻⡝⡎⡎⣍⣟⣞⣟⡾⣵⣳⢽⣳⣫⣽⡺⡝⣜⢜⣮⣳⣳⣝⣗⣟⡮⣗⣯⣞⣗⡷⣽⡳⡯⣷⣻⢽⣻⣞⡿⣝⣯⢯⣗
⡷⣟⡾⣯⣟⣷⣻⢾⣻⡾⣽⡯⣿⡽⣾⢷⣻⣟⣾⣳⡯⣿⢽⣽⣺⣼⢾⡮⣮⣎⢎⠪⡙⡰⡨⢨⠹⣺⣻⣽⡿⣾⣻⣺⣪⢪⡯⣟⡎⣷⢱⣻⣪⢿⣟⣗⡕⡌⣮⢞⢔⡪⡷⡯⣻⣞⢾⢽⣺⣺⢶⣜⣜⣎⣞⣾⣺⣞⣾⣺⢾⢽⡽⣞⣞⣗⣯⢷⣻⣽⣳⢯⡯⣗⡯⣟⣽⢽⣫⢷
⢽⢯⣟⣷⣻⢾⡽⣿⢽⣯⢷⣟⣯⡿⣽⢯⣷⣻⣞⣷⣻⢯⣟⣷⣻⣞⡯⣟⣗⣯⢸⢺⢪⣢⣫⣾⣜⢮⢞⣗⣯⣳⣳⣳⢯⢷⣟⣗⣇⢿⡸⣺⣳⢫⣿⣞⡾⣽⣟⣯⢿⢞⡮⣯⢷⢯⢿⢽⣳⢯⣷⣳⣟⣮⢷⣳⣗⣷⣳⢯⡿⣽⡽⣽⢞⣗⡯⣟⣗⡷⣯⢿⡽⣽⢽⣳⢯⣻⣺⣻
⡻⡝⣾⡺⡽⣯⢿⣽⣻⢾⣻⣽⢾⡯⣿⡽⣾⣳⣟⣾⡽⣯⣷⣻⢾⣺⡯⣟⡾⡽⣽⢽⣳⢯⣻⣽⢿⡽⣽⣺⣺⣺⣺⡾⣫⡇⢷⢕⡷⡱⣯⡚⣞⡮⣫⣷⣿⣿⣻⣾⣻⢿⢽⡽⡽⡯⡿⣽⢽⣽⣺⣞⣾⣺⢯⣗⣟⢾⣝⡯⡯⣗⣯⢯⢏⢮⢝⣗⣯⣻⣞⡯⣯⢯⡻⡮⡣⠡⡣⡳
⣝⢎⢖⢽⣫⢯⣟⡾⣽⢯⣿⣺⢿⡽⣗⡏⣧⣻⣞⣷⣻⢗⣟⣾⣻⣳⣟⢿⢽⢯⡷⣻⣺⢽⣺⣺⣻⣽⣳⣻⣞⣾⡯⡿⡽⡼⣹⡕⣏⢗⢵⣳⢱⣫⢗⡽⣹⣟⡾⣳⢽⢯⣗⡯⣟⡽⡽⡾⣽⣺⣺⣺⣺⡺⣽⣺⣺⡳⣳⢯⢯⣗⡯⣟⢮⣳⢽⣺⣞⣞⣞⢾⢵⡫⡯⡺⣜⣕⢕⣝
⣪⢷⢽⣕⢷⣝⣞⡽⣽⢽⣞⡾⡯⡯⣷⣻⣳⣗⣯⢾⣺⢯⣟⣞⡾⡵⡯⡯⣯⣻⡺⡯⣯⡻⡮⣷⢯⢿⡿⣽⣾⢷⣻⡣⡋⡻⣺⣪⢯⢇⡇⣟⣎⢎⢧⢫⢮⣾⣽⢾⣯⣳⣳⢽⢵⢯⢯⣻⡺⣺⡪⣞⢮⣻⡪⣞⢮⢞⣗⢯⣳⡳⡽⣝⢽⣺⣫⡳⣻⢺⣓⢏⢟⢞⡽⣝⢮⢾⢵⣝
⢯⢯⣗⠯⣷⣳⣳⢿⡽⣯⢾⡽⣽⣫⣗⢷⣳⣳⢽⢽⣺⢽⡺⡮⡯⡯⣯⣻⡺⡮⡯⡯⣺⢽⢝⡾⣝⢗⢯⣳⡫⡿⣷⣷⡮⣜⡔⣎⢎⢇⢧⢣⡿⡮⣮⢯⣟⣾⣺⣝⡮⡺⣜⣝⢭⡳⣛⡞⡮⡳⣝⢮⡳⡵⣝⢮⣫⡳⡳⣝⢮⢮⡳⡽⣕⣗⢗⡽⣳⢽⡺⡽⡽⡽⣹⢝⣞⢽⡳⡵
⣫⢯⢆⡇⣗⢟⡞⡽⣝⡽⣳⢝⣞⢮⡺⣝⢮⡺⡽⣝⢾⢽⢝⡽⣝⢽⡪⣞⢮⣻⡪⡯⣞⣵⣻⡺⡮⣯⣗⣗⡯⣟⣷⢯⣯⢾⡮⣷⡽⣽⢽⣿⣽⡾⣯⡿⣽⣞⣷⢯⡿⣝⡮⣮⣳⣝⣞⢮⡫⡯⣺⢵⢝⣞⢮⡳⡵⣝⣝⢮⡳⣝⡮⡯⣺⣪⢯⣻⡺⣽⡺⡽⣺⢽⢕⣟⢮⢧⢹⡺
⡕⡧⡳⡹⣜⢵⢝⢮⡺⡼⣕⢯⢞⢵⢻⡪⣗⢯⡫⣞⢽⢹⡹⣪⢳⢝⢮⢳⢳⢕⢽⡹⣪⢺⢜⢮⢯⡺⣪⢯⡿⣯⢿⡽⣾⣻⡽⣷⣻⢯⡿⣷⣟⡿⣯⢿⣽⣞⣯⣟⣟⣯⣟⣷⣳⢻⡺⣕⢯⢫⢮⡳⣝⣮⡺⣪⣳⡣⣗⡽⣺⢕⡷⣝⣞⢮⣳⡳⡽⡮⡯⡯⣳⢯⢕⢕⡙⡎⡎⠮
⢯⡪⣳⢹⢜⢎⢗⢝⢜⢕⠵⡕⣝⢭⢣⢫⢪⢪⡪⡎⡎⡇⡏⡎⡇⡗⡝⡜⡕⡝⡜⡜⡜⡜⢎⢇⢏⢎⢏⢽⣽⣯⣷⣻⢞⣾⣺⣳⢯⢿⢽⢯⣿⣻⣽⣟⣷⣿⡪⡣⡫⡪⡪⡺⡸⡹⡪⣳⢹⡹⡕⡏⣖⠷⢽⢕⢷⢝⣗⢯⢷⡻⣞⢾⡪⡷⡵⡝⣞⡺⣪⡫⡮⡫⣫⢣⢝⢼⢬⢣
⡎⡞⡜⡜⡜⡎⡮⡪⡪⡣⡫⡪⡒⡕⡕⡕⡕⡕⡜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢌⢎⢜⢜⢜⢜⢜⢜⢜⢻⢻⢺⢳⢣⢣⢣⢪⢪⢣⢫⢣⢫⢪⢍⢏⢝⢝⢜⢎⢎⢎⢎⢎⢎⢎⢎⢮⢪⡣⡳⡱⡱⡱⡩⡣⡣⡳⡱⡪⡎⣇⢧⢳⢱⡹⣸⡪⡺⣪⢺⢪⢺⡸⡱⣕⢝⡜⣕⢝⡎
⢣⢣⢣⠫⡪⡚⡜⡪⢪⠪⡪⢪⢚⢪⠪⡚⡜⢜⢸⢘⢔⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⡱⡑⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡝⡜⡕⣕⢕⢕⢕⢕⢝⢼⢸⢸⢸⢸⢸⢸⢱⢱⡱⡱⡱⡱⡹⡸⡪⡣⡳⡱⡹⡸⡸⡸⡸⡜⣎⢮⢣⡳

        
⠡⡡⢡⠑⢅⠣⡑⢕⠱⡱⡩⡪⡪⡱⡱⡩⡪⡪⣱⢕⢍⢎⢎⢎⢎⠪⡊⢎⠪⣊⠪⣊⠪⡊⡪⡊⡪⡊⢎⢊⠪⡊⢎⠪⠪⡪⡊⢎⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡪⢪⠪⡫⡝⡭⣫⢯⠯⡯⣏⢯⣫⣫⣝⣝⢽⢽⢝⡽⢭⡫⣫⡫⡳⣹⢹⣹⡹⡭⡫⣝⢵
⢂⢊⠢⠡⡡⡑⢌⠢⡑⢌⠪⡪⢪⠪⡪⢪⠪⡪⡪⣷⢑⢕⠕⡕⢕⢕⢱⢑⢕⢢⠣⡢⣃⢇⢪⠨⠢⡊⡢⡑⡑⢌⠢⡑⡑⢌⢌⠢⡑⢌⠢⡣⠱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡑⡕⡱⡡⡃⢎⠢⡃⡇⣏⢮⢗⣯⢯⡺⡪⣇⢗⢮⣞⢮⣗⢯⣳⡫⣗⢽⡪⡮⡳⣕⢽⢜⢮⡪⣇⢗⢵
⢂⠢⠡⡑⡐⠨⡐⡑⢌⠢⡑⢜⠸⡘⡜⢌⢎⢪⠪⣟⣎⢆⢇⢣⢣⠱⡡⡣⡑⡅⢇⢪⡞⢌⠢⡑⢅⢕⢐⠕⢌⠢⡑⢌⢌⠢⠢⡑⢌⠢⡑⠜⡌⡪⡘⡌⢎⢜⢌⢎⢜⢌⢎⠜⡔⡑⡌⡪⡘⡌⡪⣪⢏⢮⢯⣗⡯⣳⢵⢝⣞⢮⣗⢽⢕⣗⢽⣪⡳⡝⡮⡺⣜⢮⢳⡣⡳⣕⣝⢵
⢐⠨⢂⠢⡈⡂⡢⠨⡂⢕⠨⠢⡑⡑⢌⠢⡑⢕⠱⡽⡵⡕⡅⢇⢪⠪⡢⡑⢕⢘⢬⡟⢌⠢⡑⢌⠢⠢⢡⠡⡡⡑⢌⢂⠢⠡⡑⢌⠢⡑⢌⢊⠢⡑⢌⠪⡘⢔⠱⡨⢢⠣⡊⡎⢜⢌⠆⡕⢌⢪⢸⢸⢝⢎⢧⡳⡯⡯⣫⢗⣗⢯⢮⣫⡳⣕⢗⣕⢧⢫⡺⣪⡺⣪⡣⡏⣞⢎⢮⡺
⠐⠨⢐⢐⢐⠐⢌⠐⢌⠐⢅⢑⠐⢌⠢⡑⠌⡌⡊⡾⡯⣗⠜⡌⢆⢣⠪⡨⠢⣱⡟⢌⠂⢕⠨⡂⠅⠕⢅⢑⢐⢌⢂⢢⣡⣕⣎⢦⢇⢮⠢⠡⡃⡪⠢⡑⢌⠢⡑⢌⠢⠣⡑⢜⠌⢆⢕⠸⡨⢢⢣⢳⡹⡕⣇⢏⡯⡯⡯⣳⢯⣫⢺⢜⢮⡳⣝⣜⢮⢣⡳⣕⢝⢖⢵⡹⣪⡫⣇⢯
⠨⢈⢐⠐⡐⠨⠠⠑⢄⢑⠐⠄⠅⢅⠑⠌⢌⢂⠢⣻⣝⡿⡌⠌⢌⠢⡣⢱⣹⣗⢃⠢⡑⠄⢕⠨⠨⡊⠢⡑⡐⢔⢰⣳⢷⣕⣗⡝⡵⡕⢯⠨⡂⡪⠨⡊⡢⡑⢌⠢⡑⡑⢌⠢⡑⡑⡌⡪⡘⢜⢜⡕⡧⣫⢪⢮⢺⣫⢯⣏⡗⣎⢗⣝⢕⢧⡳⡪⡮⣣⢳⢕⡽⡕⡧⡫⡮⡺⣜⢮
⢐⠐⡐⢐⠠⠡⠈⠌⡐⠠⢁⠅⠅⡂⠅⡑⢐⠠⠡⣗⢷⣝⡧⠡⠡⡱⡘⣼⣳⢗⡅⢕⠨⡈⠢⠡⡑⠌⢌⢂⢊⢢⣟⣞⣿⣳⢵⢝⠼⡕⣝⡕⢌⢌⢊⠢⡂⡪⠢⡑⢌⢌⠢⡑⢌⠢⡊⢆⠕⡕⣇⢯⢺⢜⢕⡕⡧⣫⣗⢷⡹⣜⢵⡱⣝⢵⡹⣪⡺⣪⢣⡳⡵⡝⣎⢗⣝⢮⣗⢯
⠄⡂⢂⠂⠌⡐⠡⢁⠂⠅⡂⠌⡐⠠⢡⠂⠅⡊⠢⠩⡳⣳⢽⡘⢌⢢⣺⢽⢊⢏⢯⡢⢑⠌⢌⢂⠪⡨⡂⢆⢱⣝⢾⢿⣾⢯⣻⡪⡝⣞⢢⡗⡕⡐⡅⠕⢌⢌⠪⡨⡂⠆⢕⢌⠢⡃⢎⠢⡣⡱⡕⡧⡳⡹⡜⣎⢞⣺⡺⣽⡺⡪⣎⢞⡜⡮⣺⡪⡺⣜⢵⡹⣪⡺⣜⣗⡽⣕⡯⣏
⢐⢐⢐⠨⢐⠠⡁⠢⠨⢐⠠⡁⡂⢅⠢⠹⢦⡨⡈⠢⢑⢕⢗⠕⢠⢳⢙⢐⢐⡸⣕⢯⠐⠌⡂⡢⡑⡐⢌⢢⣳⣯⣯⣟⢝⢔⡷⡕⣝⢼⢘⢎⢎⢪⠨⡊⢆⢢⠱⡰⡘⢌⠆⢆⠣⡪⡘⡌⢆⢇⢗⢵⢹⢪⢺⢸⢪⡺⣺⢵⢯⡣⡳⣕⢝⢮⡳⣝⢝⢮⡻⣺⣳⢯⢗⣗⡽⡮⣻⣪
⡰⡐⡆⢎⠢⡣⡢⡣⡱⡨⡒⡌⢎⢎⠪⡪⡪⡹⣺⢬⢠⢀⡱⣕⢮⢂⢰⢰⢫⢸⢸⢪⢈⢂⢂⢂⡂⠪⡐⣼⢮⣳⡟⡊⡂⣳⣝⢮⢪⠇⢝⡗⢕⣅⢣⢑⠕⡌⡪⢢⢑⢅⠣⡑⢕⠌⡆⢕⢕⢕⢇⢗⢝⡜⣕⢝⡜⡮⡯⡯⡷⡝⣎⢮⡫⣮⣻⣺⢝⣗⡽⣳⢽⢯⢯⡺⣺⢝⡮⣞
⠪⡘⡸⡰⡑⢌⢆⢣⢊⢆⢇⢇⢇⢇⢣⢱⢑⠕⣜⠜⢑⠑⢜⡎⠯⠊⡂⢎⡮⡺⡸⡸⢐⢐⢰⡳⡅⣱⣸⡫⣷⢗⠱⡨⢪⣞⢼⢸⡸⡎⢦⡪⡂⡇⢆⢕⢑⢌⠪⡢⡑⢌⢪⢘⢔⠱⡘⡜⡜⡎⡇⡏⣎⢮⢪⡺⣸⢝⡾⡽⣹⢽⡸⣕⡽⣺⣺⣺⢽⢮⢫⡯⡿⡽⣕⢯⡳⡽⣺⢵
⡡⡱⡱⡘⢜⢌⢆⢇⢎⢎⢆⢕⢕⢕⢱⢸⢨⢪⢱⡑⡆⠌⡜⢌⢂⢕⢆⠅⡕⡯⡣⡣⡑⢔⠸⣞⣽⢜⡮⣟⢞⠰⡑⢌⡯⡮⡣⡇⣇⢥⣑⡕⣍⠪⠢⡡⠱⡨⡊⡢⡑⠕⢔⠱⡨⢪⢪⢪⢪⡪⡺⡸⡜⡜⣎⢞⡮⡷⡽⣝⢮⢟⡮⣺⡺⡵⣳⢽⢽⢽⢵⢯⢿⣝⡮⣗⡽⡽⣵⣻
⢜⢜⢼⢸⢸⡰⡱⡕⣎⢮⡢⡱⡑⡕⢕⠕⡥⡳⡕⢕⠕⣕⢇⢇⡇⢜⢵⢝⢮⢑⢜⠰⠨⠢⡑⢝⣯⡿⢝⢌⠢⡑⢌⣞⣝⢎⠧⡫⡞⢔⢸⡫⡌⢣⠣⡊⡪⠢⡑⢌⢜⢘⢌⢪⢸⢸⢸⢸⢸⢸⢪⢪⢎⢧⢳⢍⢯⢯⣻⣺⢵⢯⣻⡪⣞⡽⣳⢽⢯⢯⣫⢯⣟⣞⢾⢵⣫⢯⢾⣺
⡪⡳⡝⣎⣗⢝⢮⢫⡪⡎⣞⢕⢧⢣⠣⡝⡎⡧⡣⡑⢈⢎⢎⢞⢜⠜⡜⡵⡫⡬⡢⣑⣅⡃⡊⡂⡂⡊⢆⠢⡑⣌⡾⡜⡮⡳⡱⡑⢌⠢⡱⣫⢆⠑⢅⠪⡨⠪⡨⠢⡑⢌⠢⡱⡱⡱⡕⡕⣕⢵⢱⡣⡳⡕⣗⢝⡎⡟⡾⡽⡽⡽⣎⢯⣺⢽⡵⣟⣽⢯⢞⣗⣷⣫⢯⢷⢽⢽⢽⣺
⡪⡫⡮⡳⣕⡏⣗⢵⢕⣝⢜⢮⡫⣳⢕⡇⡯⡺⡪⡪⡪⡪⡪⡪⡪⡪⡪⣞⢕⢕⢇⡇⡇⡯⡳⣳⣲⣔⢄⢂⠌⣺⢮⠳⡑⢅⠅⡌⡐⡨⣺⣵⢧⢅⠀⠳⡨⠪⡨⠪⡨⠢⡑⡕⡕⡵⡹⡜⣎⢮⡣⣫⢪⡳⣕⢗⡝⣎⢯⢯⢯⣻⣪⢟⣞⢷⢽⢽⣺⢯⣻⣺⣺⢾⢽⢽⢽⢽⢽⣺
⡪⣳⢝⣝⢮⡺⡵⣝⢮⣪⡳⣳⡹⣪⡳⣝⢼⡪⡳⡳⣕⢵⢱⡱⡱⡱⣱⡣⡇⡇⢇⢎⢪⢪⢺⢸⢜⢮⣻⢦⢣⡳⡲⣝⢮⣳⣽⣭⢯⣺⢽⢝⣷⡹⣲⢤⣁⠣⠨⠪⠨⠨⡸⡸⡸⣪⡣⣏⢞⡼⡪⡪⡧⣫⢮⢺⡪⡺⡪⡯⣻⢺⡺⣝⢾⢽⢝⡽⣞⣟⣞⣞⣞⣯⢟⡽⡽⣽⢽⣺
⡪⣗⣝⢮⡳⣝⣞⢮⡳⡵⣝⢮⡺⡵⣝⢮⡳⣹⢜⢽⡸⣪⢗⢵⣫⢪⢲⢕⢯⢪⠪⡪⡪⡪⡪⡪⣪⢳⢕⣗⢷⢝⢮⢪⢮⣺⡺⣪⢫⢝⢜⢝⢮⡻⣞⢷⠽⡵⣕⢬⢦⢧⢶⢜⣬⡪⣪⢞⡵⡳⡹⡘⣝⢮⢪⡣⡫⣎⢗⣝⢮⢣⢏⢾⢝⣗⡯⣟⡾⣺⣺⣺⣺⢽⡽⣽⣫⡯⣟⡾
⢝⡞⡮⣳⢽⡺⣜⢗⡽⣝⣞⢽⢺⢝⡮⣳⢝⡮⣳⡣⡯⣪⢯⡳⣕⢗⢝⡽⡸⡰⡱⡑⡕⡜⢜⢜⡼⣽⣽⢽⢽⣕⡯⣯⣻⠪⠹⣎⢧⡳⣕⢽⠱⡯⣎⢧⡫⣎⢷⡝⡽⡽⡝⡝⣜⢮⢳⡳⡝⣜⢎⢆⠑⡝⡮⣪⡳⡱⡱⡪⡪⣊⢊⢈⠑⠧⡯⣳⣻⣳⣳⡳⣯⣻⡽⣳⣳⢯⡷⣻
⢳⡹⣝⢮⡳⣝⡮⡯⣺⡪⣞⢎⣗⣝⢮⡳⣫⢞⣕⢗⡽⣜⡵⣝⢮⡳⡝⣎⢎⢎⢪⠪⡪⡪⣮⢿⣽⣷⣟⣯⡿⣞⣯⡷⣇⡯⣪⡘⣳⡽⣮⡳⢁⢊⡯⣷⣝⣞⢮⣻⣪⢪⢪⣪⢺⡪⣳⡹⣪⢺⡸⡪⡂⡈⠺⢸⠘⠌⢌⢂⢇⢧⠱⡐⡠⢈⠺⡜⡮⣺⢮⢯⣗⣷⣻⢽⣞⡯⣯⢿
⢕⡝⡮⡳⡽⣕⢯⢞⣗⣝⢮⡳⣕⢧⡳⣝⢮⡳⡳⣝⢮⡺⣺⣪⡳⣝⢞⣾⢯⢣⣣⣳⡽⣽⣯⣿⣿⢷⣻⣷⡿⣫⢯⡻⡶⡟⡆⢇⠂⢫⢿⡧⣳⣝⡾⣮⣿⣾⣻⣎⢷⢝⢮⡪⡧⡫⡮⡺⣜⢵⢝⢵⢱⠠⡂⡐⠌⡊⢆⠅⢯⢎⢗⢕⢌⢆⢂⠱⡹⣪⢯⣗⡷⣳⡯⣟⡾⣽⢽⣽
⡪⡮⡳⣕⣝⢮⣫⡳⣕⢗⣗⢽⣪⢗⡽⡮⣳⢽⣹⡪⣗⢽⡺⣜⢾⢕⣯⣺⡽⣗⣿⣺⣟⣿⣽⣿⣯⣿⣿⣿⣟⢌⠌⡊⡘⢈⠃⠡⢈⠠⠑⣟⠺⡽⣝⢾⣻⣿⣿⡾⣝⣯⢺⡪⣳⢹⡪⣺⣪⢳⢝⣕⢇⢇⢢⢂⠁⠄⠠⢈⠘⣎⢧⢣⢣⢕⢌⡂⢝⢮⣳⣳⣻⣳⣻⣳⣻⢽⢽⣺
⢮⢎⢯⢎⡞⣜⢖⣝⢮⡳⣕⢯⢮⢯⢞⡽⣪⢷⢕⡯⣺⢵⡫⣞⢵⣫⢞⡼⡝⡝⢯⢻⡛⡏⢯⡷⣿⣻⣿⣽⣿⣎⢆⢆⢂⠢⡈⠄⠧⡢⢁⠄⠅⡊⠌⢕⣿⡿⣾⣿⣟⡾⣕⢕⢧⢳⡹⡜⣎⢗⡝⣎⢯⢺⡸⡰⡡⢅⢅⠂⢄⠸⣪⡫⡎⡎⡆⡕⡐⣕⢗⣗⣯⢾⡽⣞⡽⡽⡽⣮
⡸⡵⡝⡮⣺⢸⢕⡕⡧⣫⢞⣝⢮⣳⣫⢾⣹⢵⡫⣞⡵⣫⢞⡵⣝⢮⡳⣝⢎⢪⠪⡢⡣⡣⣻⣟⣿⣿⣻⣿⣻⣿⣷⣵⢥⢅⠍⠭⡓⡮⠲⡈⢆⢪⣪⣾⣿⣟⣿⣻⣯⣿⡽⣞⢜⢎⢮⢺⡸⡱⡹⡸⡸⡱⡱⡱⡱⡱⡡⡑⠀⠂⣇⢯⡪⡪⡪⡪⡂⡪⡯⣞⣞⣯⢟⣷⢽⢽⣽⣻
⢮⡳⣝⡞⡮⡳⣕⢝⢮⢎⡗⡵⣫⡺⡼⣕⣗⢗⣝⢮⢯⢎⢇⢏⢎⢇⢯⢎⢪⢢⠣⡣⡱⡱⣿⣻⣽⣾⣿⣻⣟⣯⣿⣿⣟⡷⣽⣰⢰⣸⣼⣮⣷⣿⣿⣿⣟⣯⣿⣽⡿⣷⣻⡯⡳⣹⢸⢱⢱⢱⢑⠕⢜⠌⡌⡪⡈⡂⠢⢨⢠⢪⢸⣪⢺⢜⢜⢔⢕⠌⡯⣻⡺⡽⣝⣗⣟⣽⣺⣺
⣳⣫⡳⣝⣞⣯⡿⣽⣯⢷⡿⣽⣗⣯⣿⣺⣞⣿⣺⣽⢷⣻⣽⢷⣱⢱⢱⢇⢣⢱⠱⡑⡕⣽⣟⣿⣻⣿⣽⣿⣿⢿⠟⡗⡵⣍⢕⢳⢯⣳⢽⢯⢿⣻⣿⣟⣿⣿⣟⣷⣏⡧⣗⡵⣹⢜⡜⣜⡼⡼⣜⣝⣜⢕⢇⢇⢧⡳⣫⢳⡹⡜⣜⢎⣗⢽⡱⡳⣱⢵⣻⣺⡮⡯⣷⣻⣞⣷⣻⣾
⡿⣮⡫⣞⣝⣽⣿⣻⣾⢿⣻⣫⢫⢻⢺⢻⣽⡷⣟⣿⣻⢿⡽⡹⡸⡸⡸⡕⡱⡑⢕⠱⣸⢷⣟⣯⡿⣷⢿⢳⡹⣪⢯⣪⢺⡸⣹⢨⣳⠨⡯⡳⡵⣗⣝⢿⣯⣿⣿⣽⣾⣻⣽⡽⣽⣝⢮⣗⣯⣟⣗⣟⣞⢯⢯⢯⣳⢽⣪⣗⣽⡺⣮⣳⢳⡳⣕⣝⢵⣫⢟⣾⡻⣪⡺⣜⣯⣯⢷⡷
⣯⣗⣽⣺⢾⣽⢾⣻⡺⣵⡳⣕⡯⡮⣇⢗⣝⡿⣯⡷⣟⣯⡇⡇⡇⡇⡇⡇⢇⣎⢎⣪⢾⣻⣽⢯⡫⡮⢪⡺⣽⣺⣻⣝⢧⢹⡪⣇⢷⢭⢯⡇⡯⣗⢯⢶⡱⠽⣾⢿⡾⣞⣮⢮⡪⣪⣳⣳⢳⡳⡲⡲⡸⡨⡳⣕⢧⣫⢳⢝⡞⣝⢮⢮⡳⣽⣺⡺⣽⡺⣽⢽⢽⢮⡺⡮⡷⡯⡿⣝
⣷⣳⣯⢿⡽⣯⣟⣷⢽⣾⣺⢷⡽⣽⣺⣳⡵⣟⣷⣟⣯⡷⣟⢜⢜⢜⢜⢜⢔⢺⢽⣞⡏⢝⠚⣕⢝⣜⡵⣟⣾⣯⣷⣯⣗⢵⢝⢮⣺⣝⢽⡺⣜⣯⢯⣳⡻⡝⡎⡎⣍⣟⣞⣟⡾⣵⣳⢽⣳⣫⣽⡺⡝⣜⢜⣮⣳⣳⣝⣗⣟⡮⣗⣯⣞⣗⡷⣽⡳⡯⣷⣻⢽⣻⣞⡿⣝⣯⢯⣗
⡷⣟⡾⣯⣟⣷⣻⢾⣻⡾⣽⡯⣿⡽⣾⢷⣻⣟⣾⣳⡯⣿⢽⣽⣺⣼⢾⡮⣮⣎⢎⠪⡙⡰⡨⢨⠹⣺⣻⣽⡿⣾⣻⣺⣪⢪⡯⣟⡎⣷⢱⣻⣪⢿⣟⣗⡕⡌⣮⢞⢔⡪⡷⡯⣻⣞⢾⢽⣺⣺⢶⣜⣜⣎⣞⣾⣺⣞⣾⣺⢾⢽⡽⣞⣞⣗⣯⢷⣻⣽⣳⢯⡯⣗⡯⣟⣽⢽⣫⢷
⢽⢯⣟⣷⣻⢾⡽⣿⢽⣯⢷⣟⣯⡿⣽⢯⣷⣻⣞⣷⣻⢯⣟⣷⣻⣞⡯⣟⣗⣯⢸⢺⢪⣢⣫⣾⣜⢮⢞⣗⣯⣳⣳⣳⢯⢷⣟⣗⣇⢿⡸⣺⣳⢫⣿⣞⡾⣽⣟⣯⢿⢞⡮⣯⢷⢯⢿⢽⣳⢯⣷⣳⣟⣮⢷⣳⣗⣷⣳⢯⡿⣽⡽⣽⢞⣗⡯⣟⣗⡷⣯⢿⡽⣽⢽⣳⢯⣻⣺⣻
⡻⡝⣾⡺⡽⣯⢿⣽⣻⢾⣻⣽⢾⡯⣿⡽⣾⣳⣟⣾⡽⣯⣷⣻⢾⣺⡯⣟⡾⡽⣽⢽⣳⢯⣻⣽⢿⡽⣽⣺⣺⣺⣺⡾⣫⡇⢷⢕⡷⡱⣯⡚⣞⡮⣫⣷⣿⣿⣻⣾⣻⢿⢽⡽⡽⡯⡿⣽⢽⣽⣺⣞⣾⣺⢯⣗⣟⢾⣝⡯⡯⣗⣯⢯⢏⢮⢝⣗⣯⣻⣞⡯⣯⢯⡻⡮⡣⠡⡣⡳
⣝⢎⢖⢽⣫⢯⣟⡾⣽⢯⣿⣺⢿⡽⣗⡏⣧⣻⣞⣷⣻⢗⣟⣾⣻⣳⣟⢿⢽⢯⡷⣻⣺⢽⣺⣺⣻⣽⣳⣻⣞⣾⡯⡿⡽⡼⣹⡕⣏⢗⢵⣳⢱⣫⢗⡽⣹⣟⡾⣳⢽⢯⣗⡯⣟⡽⡽⡾⣽⣺⣺⣺⣺⡺⣽⣺⣺⡳⣳⢯⢯⣗⡯⣟⢮⣳⢽⣺⣞⣞⣞⢾⢵⡫⡯⡺⣜⣕⢕⣝
⣪⢷⢽⣕⢷⣝⣞⡽⣽⢽⣞⡾⡯⡯⣷⣻⣳⣗⣯⢾⣺⢯⣟⣞⡾⡵⡯⡯⣯⣻⡺⡯⣯⡻⡮⣷⢯⢿⡿⣽⣾⢷⣻⡣⡋⡻⣺⣪⢯⢇⡇⣟⣎⢎⢧⢫⢮⣾⣽⢾⣯⣳⣳⢽⢵⢯⢯⣻⡺⣺⡪⣞⢮⣻⡪⣞⢮⢞⣗⢯⣳⡳⡽⣝⢽⣺⣫⡳⣻⢺⣓⢏⢟⢞⡽⣝⢮⢾⢵⣝
⢯⢯⣗⠯⣷⣳⣳⢿⡽⣯⢾⡽⣽⣫⣗⢷⣳⣳⢽⢽⣺⢽⡺⡮⡯⡯⣯⣻⡺⡮⡯⡯⣺⢽⢝⡾⣝⢗⢯⣳⡫⡿⣷⣷⡮⣜⡔⣎⢎⢇⢧⢣⡿⡮⣮⢯⣟⣾⣺⣝⡮⡺⣜⣝⢭⡳⣛⡞⡮⡳⣝⢮⡳⡵⣝⢮⣫⡳⡳⣝⢮⢮⡳⡽⣕⣗⢗⡽⣳⢽⡺⡽⡽⡽⣹⢝⣞⢽⡳⡵
⣫⢯⢆⡇⣗⢟⡞⡽⣝⡽⣳⢝⣞⢮⡺⣝⢮⡺⡽⣝⢾⢽⢝⡽⣝⢽⡪⣞⢮⣻⡪⡯⣞⣵⣻⡺⡮⣯⣗⣗⡯⣟⣷⢯⣯⢾⡮⣷⡽⣽⢽⣿⣽⡾⣯⡿⣽⣞⣷⢯⡿⣝⡮⣮⣳⣝⣞⢮⡫⡯⣺⢵⢝⣞⢮⡳⡵⣝⣝⢮⡳⣝⡮⡯⣺⣪⢯⣻⡺⣽⡺⡽⣺⢽⢕⣟⢮⢧⢹⡺
⡕⡧⡳⡹⣜⢵⢝⢮⡺⡼⣕⢯⢞⢵⢻⡪⣗⢯⡫⣞⢽⢹⡹⣪⢳⢝⢮⢳⢳⢕⢽⡹⣪⢺⢜⢮⢯⡺⣪⢯⡿⣯⢿⡽⣾⣻⡽⣷⣻⢯⡿⣷⣟⡿⣯⢿⣽⣞⣯⣟⣟⣯⣟⣷⣳⢻⡺⣕⢯⢫⢮⡳⣝⣮⡺⣪⣳⡣⣗⡽⣺⢕⡷⣝⣞⢮⣳⡳⡽⡮⡯⡯⣳⢯⢕⢕⡙⡎⡎⠮
⢯⡪⣳⢹⢜⢎⢗⢝⢜⢕⠵⡕⣝⢭⢣⢫⢪⢪⡪⡎⡎⡇⡏⡎⡇⡗⡝⡜⡕⡝⡜⡜⡜⡜⢎⢇⢏⢎⢏⢽⣽⣯⣷⣻⢞⣾⣺⣳⢯⢿⢽⢯⣿⣻⣽⣟⣷⣿⡪⡣⡫⡪⡪⡺⡸⡹⡪⣳⢹⡹⡕⡏⣖⠷⢽⢕⢷⢝⣗⢯⢷⡻⣞⢾⡪⡷⡵⡝⣞⡺⣪⡫⡮⡫⣫⢣⢝⢼⢬⢣
⡎⡞⡜⡜⡜⡎⡮⡪⡪⡣⡫⡪⡒⡕⡕⡕⡕⡕⡜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢌⢎⢜⢜⢜⢜⢜⢜⢜⢻⢻⢺⢳⢣⢣⢣⢪⢪⢣⢫⢣⢫⢪⢍⢏⢝⢝⢜⢎⢎⢎⢎⢎⢎⢎⢎⢮⢪⡣⡳⡱⡱⡱⡩⡣⡣⡳⡱⡪⡎⣇⢧⢳⢱⡹⣸⡪⡺⣪⢺⢪⢺⡸⡱⣕⢝⡜⣕⢝⡎
⢣⢣⢣⠫⡪⡚⡜⡪⢪⠪⡪⢪⢚⢪⠪⡚⡜⢜⢸⢘⢔⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⡱⡑⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡝⡜⡕⣕⢕⢕⢕⢕⢝⢼⢸⢸⢸⢸⢸⢸⢱⢱⡱⡱⡱⡱⡹⡸⡪⡣⡳⡱⡹⡸⡸⡸⡸⡜⣎⢮⢣⡳
      */
        string[] input = Console.ReadLine().Split(' ');
        float a = int.Parse(input[0]);
        float b = int.Parse(input[1]);
        float aa = a * b / 2;
        Console.WriteLine(aa.ToString("F1"));
    }
}