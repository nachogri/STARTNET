<?xml version="1.0" encoding="utf-8"?>
<xslt:stylesheet version="1.0" xmlns:xslt="http://www.w3.org/1999/XSL/Transform">
    <xslt:template match="/">
      <table style="padding-right:5px; "
                cellpadding="0" cellspacing="0" class="LetraGeneral" >
       <xslt:for-each select="Promociones/Promocion">
        <tr>
          <td>
          </td>
          <td rowspan="4">            
          </td>
          <td class="LetraFormateadaNegraBold">
            <xslt:value-of select="nombre"></xslt:value-of>
          </td>
          <td>           
          </td>
        </tr>
        <tr>
          <td >
          </td>
          <td>           
            Expiración: <xslt:value-of select="expiracion"></xslt:value-of>             
          </td>
          <td >
          </td>
        </tr>
        <tr>
          <td>
          </td>
          <td>
            <span>
              Requisitos: <xslt:value-of select="requisitos"></xslt:value-of>
            </span>
          </td>
          <td>
          </td>
        </tr>       
        <tr>
          <td>
          </td>
          <td colspan="2"
              style="background-image: url('../resources/images/menu_separator.gif')"
              height="1"></td>
          <td
              style="background-image: url('../resources/images/menu_separator.gif')"
              height="1"></td>
        </tr>
        </xslt:for-each>
      </table>      
    </xslt:template>
</xslt:stylesheet>
