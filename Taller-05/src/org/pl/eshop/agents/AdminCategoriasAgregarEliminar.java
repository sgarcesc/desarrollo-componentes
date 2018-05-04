package org.pl.eshop.agents;

import jade.core.behaviours.CyclicBehaviour;
import jade.lang.acl.ACLMessage;
import org.pl.eshop.dto.Categoria;
import org.pl.eshop.dto.CategoriaDAO;
import org.pl.eshop.dto.CategoriaDAOMySQL;

public class AdminCategoriasAgregarEliminar extends CyclicBehaviour {
	String result;
	CategoriaDAO cdao = new CategoriaDAOMySQL();
	@Override
	public void action() {
		ACLMessage msg = getAgent().receive();
		if (msg != null) {			
			result = msg.getContent();
			String[] datos = result.split(",");
			if (datos[0] == "1") {
				System.out.println("Iniciando proceso para adicionar una categoria.");
				Categoria c = new Categoria();
				c.setNombre(datos[1]);
				c.setDescripcion(datos[2]);
				try {
					cdao.agregar(c);
				} catch (Exception e) {
					System.out.println("Hubo un error al acceder a la base de datos.");
				}
			}
			else {
				System.out.println("Iniciando proceso para eliminar una categoria.");
				try {
					Categoria categoria = cdao.obtenerPorId(Integer.parseInt(datos[1]));
					cdao.eliminar(categoria);
				} catch (Exception e) {
					System.out.println("Hubo un error al acceder a la base de datos.");
				}
			}
		} else {
			block();
		}
	}
}