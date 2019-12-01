#include <C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\include\GL\glut.h>
#include <C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\include\GL\freeglut.h>

float rotate_x = 0, rotate_y = 0, rotate_z = 0;
int primitive = 0;
float R = 0, G = 0, B = 0;

void randomColor()
{
	R = (rand() % 255) / 255.0;
	G = (rand() % 255) / 255.0;
	B = (rand() % 255) / 255.0;
}

void triangle()
{
	glBegin(GL_TRIANGLES);
	glVertex2f(-0.5f, -0.5f);
	glVertex2f(0.f, 0.5f);
	glVertex2f(0.5f, -0.5f);
	glEnd();
}
void triangle_color()
{
	glBegin(GL_TRIANGLES);
	
	GLfloat BlueCol[3] = { 0 , 0 , 1 };
	glColor3f(1.f, 0.f, 0.f);
	glVertex2f(-0.5f, -0.5f);
	glColor3ub(0, 255, 0);
	glVertex2f(0.f, 0.5f);
	glColor3fv(BlueCol);
	glVertex2f(0.5f, -0.5f);
	
	glEnd();
}
void rectangle()
{
	glBegin(GL_QUADS);
	glVertex2f(-0.5f, -0.5f);
	glVertex2f(-0.5f, 0.5f);
	glVertex2f(0.5f, 0.5f);
	glVertex2f(0.5f, -0.5f);
	glEnd();
}
void teapot() {	glutWireTeapot(0.5f); }
void cube() { glutWireCube(0.5f); }
void sphere() {	glutWireSphere(0.5f, 20, 20); }
void icosahedron() { glutWireIcosahedron(); }
void octehedron() {	glutWireOctahedron(); }

void draw_primitive(int n) {
	switch (n)
	{
	case 0: triangle(); break;
	case 1: triangle_color(); break;
	case 2: rectangle(); break;
	default:
		break;
	}
}

void specialKeys(int key, int x, int y)
{
	switch (key)
	{
	case GLUT_KEY_UP: rotate_x += 5; break;
	case GLUT_KEY_DOWN: rotate_x -= 5; break;
	case GLUT_KEY_LEFT: rotate_y += 5; break;
	case GLUT_KEY_RIGHT: rotate_y -= 5; break;
	case GLUT_KEY_PAGE_UP: rotate_z += 5; break;
	case GLUT_KEY_PAGE_DOWN: rotate_z -= 5; break;
	default:
		break;
	}
	glutPostRedisplay();
}

void mouseKeys(int button, int state, int x, int y)
{
	if (button == GLUT_LEFT_BUTTON && state == GLUT_DOWN)
	{
		randomColor();
		primitive = rand() % 3;
	}
}

void renderRectangle() {
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

	glRotatef(rotate_x, 1, 0, 0);
	glRotatef(rotate_y, 0, 1, 0);
	glRotatef(rotate_z, 0, 0, 1);

	glColor3f(R, G, B);

	draw_primitive(primitive);

	glLoadIdentity();
	glutSwapBuffers();
}

int main(int argc, char** argv) {
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DEPTH | GLUT_DOUBLE | GLUT_RGBA);
	glutInitWindowPosition(100, 100);
	glutInitWindowSize(800, 600);
	glutCreateWindow("OpenGL Window");

	//glEnable(GL_DEPTH_TEST);

	glutDisplayFunc(renderRectangle);
	glutSpecialFunc(specialKeys);
	glutMouseFunc(mouseKeys);

	glutMainLoop();
	return 0;
}