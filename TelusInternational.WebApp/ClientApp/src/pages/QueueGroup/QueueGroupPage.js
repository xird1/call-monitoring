import React, { Component } from "react";
import { NavMenu } from "../../components/NavMenu";
import "./QueueGroupPage.css";

export class QueueGroupPage extends Component {
  static displayName = QueueGroupPage.name;

  constructor(props) {
    super(props);
    this.state = { queueGroupData: [], loading: true, intervalId: 0 };
  }

  async componentDidMount() {
    this.populateGroupData();
    this.setState({
      intervalId: setInterval(async () => this.populateGroupData(), 10000),
    });
  }

  static renderQueueGroupDataTable(queueGroupData) {
    const formatTime = (d) => {
      d = Number(d);

      var h = Math.floor(d / 3600);
      var m = Math.floor((d % 3600) / 60);
      var s = Math.floor((d % 3600) % 60);

      return (
        ("0" + h).slice(-2) +
        ":" +
        ("0" + m).slice(-2) +
        ":" +
        ("0" + s).slice(-2)
      );
    };
    const getSLA = (d) => {
      return (
        (d.monitorData.handledWithinSL / d.monitorData.offered) *
        100
      ).toFixed(1);
    };
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Queue group name</th>
            <th>Offered</th>
            <th>Average talk time/TalkTime</th>
            <th>Average handling time/HandlingTime</th>
            <th>ServiceLevel</th>
          </tr>
        </thead>
        <tbody>
          {queueGroupData.map((data) => (
            <tr key={data.id}>
              <td>{data.name}</td>
              <td>{data.monitorData.offered}</td>
              <td>
                {formatTime(
                  data.monitorData.talkTime / data.monitorData.handled
                )}
              </td>
              <td>
                {formatTime(
                  (data.monitorData.talkTime +
                    data.monitorData.afterCallWorkTime) /
                    data.monitorData.handled
                )}
              </td>
              <td
                className={getSLA(data) < data.slA_Percent ? "warning" : "good"}
              >
                {getSLA(data)}%
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  componentWillUnmount() {
    clearInterval(this.state.intervalId);
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      QueueGroupPage.renderQueueGroupDataTable(this.state.queueGroupData)
    );

    return (
      <div>
        <NavMenu />
        <h1>Group Data</h1>
        <div></div>
        {contents}
      </div>
    );
  }

  // should make base http service in case application grows, for better maintainability and avoid repetitive code blocks
  // I've implemented a sample for functional component(loginpage)
  async populateGroupData() {
    const response = await fetch("api/queuegroup/data");
    const data = await response.json();
    this.setState({ queueGroupData: data, loading: false });
  }
}
