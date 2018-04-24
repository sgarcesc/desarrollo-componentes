package aspectos;

import dominio.*;

public aspect Logging {
	
	String mensajeObtenerCategorias = "Se ha llamado al método obtenerCategorias";
	pointcut obtenerCategorias() : call(List<Categorias> *.obtenerTodas());
	
	before() : obtenerCategorias() {
		System.out.println(mensajeObtenerCategorias);
	}
	
	String mensajeAgregarCategoria = "Se ha llamado al método agregar categoria";
	pointcut agregarCategoria() : call(void *.agregar(Categoria));
	
	before() : agregarCategoria() {
		System.out.println(mensajeAgregarCategoria);
	}
}
